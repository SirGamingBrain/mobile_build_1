using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMovement : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + (transform.forward * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + (-transform.right * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position + (-transform.forward * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + (transform.right * Time.deltaTime));
        }
    }
}
