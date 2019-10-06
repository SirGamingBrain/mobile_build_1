using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody rb;

    protected Joystick joystick;

    float xSpeed = 0f;
    float zSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.LookAt(new Vector3(0f,0f,0f));

        //Update the speed of the player.

        if (joystick.Horizontal >= -1f || joystick.Vertical >= -1f)
        {
            xSpeed += (joystick.Horizontal * .5f);

            zSpeed += (joystick.Vertical * .5f);
        }

        if (xSpeed > 0f)
        {
            xSpeed -= .1f;
        }
        else
        {
            xSpeed = 0f;
        }

        if (zSpeed > 0f)
        {
            zSpeed -= .1f;
        }
        else
        {
            zSpeed = 0f;
        }

        rb.velocity = new Vector3(xSpeed, 0,zSpeed);
    }
}
