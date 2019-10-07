using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody rb;

    protected Joystick joystick;

    bool moving = false;

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

        if (joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }

        if (moving == true) {
            float tempXSpeed = 1f * (joystick.Horizontal * .5f);

            if (xSpeed < 2.5f && xSpeed > -2.5f)
            {
                xSpeed += tempXSpeed;
            }

            float tempZSpeed = 1f * (joystick.Vertical * .5f);
            zSpeed += tempZSpeed;

            if (zSpeed < 2.5f && zSpeed > -2.5f)
            {
                zSpeed += tempZSpeed;
            }
        }

        if (moving == false)
        {
            if (xSpeed < .1f && xSpeed > -.1f)
            {
                xSpeed = 0f;
            }
            else if (xSpeed < 0f)
            {
                xSpeed += .1f;
            }
            else if (xSpeed > 0f)
            {
                xSpeed -= .1f;
            }

            if (zSpeed < .1f && zSpeed > -.1f)
            {
                zSpeed = 0f;
            }
            else if (zSpeed < 0f)
            {
                zSpeed += .1f;
            }
            else if (zSpeed > 0f)
            {
                zSpeed -= .1f;
            }
        }

        Debug.Log(xSpeed + "and speeds" + zSpeed);

        rb.velocity = new Vector3(xSpeed, 0,zSpeed);
    }
}
