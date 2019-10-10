using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private CharacterController controller;


    float speed = 2f;
    float verticalVelocity;

    Vector3 moveVector;
    Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxis("Vertical") * speed;
        controller.Move(moveVector * Time.deltaTime);


        moveVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, (verticalVelocity / 300), Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
        moveVector = this.transform.TransformDirection(moveVector);
        controller.Move(moveVector * speed);
        this.transform.Rotate(this.rotation);
    }
}
