using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody rb;

    Animator ninja;

    Vector3 forwardVel;
    Vector3 horizontalVel;

    protected Joystick joystick;

    bool moving = false;

    float xSpeed = 0f;
    float zSpeed = 0f;
    float heading = 0f;
    float dCenter = 0f;

    float debugTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        joystick = FindObjectOfType<Joystick>();

        ninja = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(new Vector3 (0f,1.5f,0f));

        //A timer to debug all of the things that I need to track.
        debugTimer += Time.deltaTime;

        dCenter = Vector3.Distance(new Vector3(0, 1.5f, 0f), transform.position);

        if (debugTimer >= 1f)
        {
            //Debug.Log("Moving: " + moving);
            //Debug.Log("Horizontal Speed: " + xSpeed);
            //Debug.Log("Vertical Speed: " + zSpeed);
            Debug.Log("Distance to Center: " + dCenter);
            debugTimer = 0f;
        }

        //Checking to see if the player is moving, and updating some animations.
        if (joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            moving = false;
            ninja.SetBool("Running", false);
        }
        else
        {
            moving = true;
            ninja.SetBool("Running", true);
        }

        //Updating the player's speed and direction of movement if they are moving, otherwise slow them overtime.
        if (moving == true)
        {
            xSpeed = joystick.Horizontal * 5f;
            zSpeed = joystick.Vertical * 5f;

            if (dCenter <= 2f)
            {
                zSpeed = 0f;
            }
        }
        else
        {
            if (xSpeed > 0.1f)
            {
                xSpeed -= .2f;
            }
            else if (xSpeed < -0.1f)
            {
                xSpeed += .2f;
            }
            else
            {
                xSpeed = 0f;
            }

            if (zSpeed > 0f)
            {
                zSpeed -= .2f;
            }
            else if (zSpeed < -0.2f)
            {
                zSpeed += .1f;
            }
            else
            {
                zSpeed = 0f;
            }
        }

        forwardVel = transform.forward * zSpeed;
        horizontalVel = transform.right * xSpeed;

        //rb.velocity = new Vector3(xSpeed, 0f,zSpeed);
        rb.velocity = (forwardVel + horizontalVel);

        //Updating the player's direction if they are moving.
        if (moving) {
            heading = Mathf.Atan2(joystick.Horizontal, joystick.Vertical);
            transform.Rotate(0f, heading * Mathf.Rad2Deg, 0f, Space.Self);
        }

        //Updating the state of animation of the player based on what is happening.

    }
}
