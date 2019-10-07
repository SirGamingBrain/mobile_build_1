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
        Debug.Log((joystick.Horizontal * .5f) + " and " + (joystick.Vertical * .5f));


        //this.transform.LookAt(new Vector3(0f,0f,0f));

        //Update the speed of the player.

        if (xSpeed < 2.5f && xSpeed > -2.5f) {
            float tempXSpeed = 1f * (joystick.Horizontal * .5f);
            xSpeed += tempXSpeed;
        }

        if (zSpeed < 2.5f && zSpeed > -2.5f) {
            float tempZSpeed = 1f * (joystick.Vertical * .5f);
            zSpeed += tempZSpeed;
        }

        if (xSpeed > -2f)
        {
            if (xSpeed < .1f && xSpeed > -.1f)
            {
                xSpeed = 0f;
            }
            else if (xSpeed < 0f)
            {
                xSpeed += .05f;
            }
            else if (xSpeed > 0f)
            {
                xSpeed -= .05f;
            }
        }

        if (zSpeed > -2f)
        {
            if (zSpeed < .1f && zSpeed > -.1f)
            {
                zSpeed = 0f;
            }
            else if (zSpeed < 0f)
            {
                zSpeed += .05f;
            }
            else if (zSpeed > 0f)
            {
                zSpeed -= .05f;
            }
        }

        Debug.Log(xSpeed + "and speeds" + zSpeed);

        rb.velocity = new Vector3(xSpeed, 0,zSpeed);
    }
}
