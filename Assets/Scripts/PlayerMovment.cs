using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody rb;

    public Animator ninja;

    protected Joystick joystick;

    bool moving = false;

    float xSpeed = 0f;
    float zSpeed = 0f;

    float heading = 0f;

    float debugTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        joystick = FindObjectOfType<Joystick>();

        ninja = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //A timer to debug all of the things that I need to track.
        debugTimer += Time.deltaTime;

        if (debugTimer >= 1f)
        {
            Debug.Log("Moving: " + moving);
            Debug.Log("Horizontal Speed: " + xSpeed);
            Debug.Log("Vertical Speed: " + zSpeed);
            debugTimer = 0f;
        }

        //Checking to see if the player is moving, updating some animations.
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
        }
        else
        {
            if (xSpeed > 0.1f)
            {
                xSpeed -= .1f;
            }
            else if (xSpeed < -0.1f)
            {
                xSpeed += .1f;
            }
            else
            {
                xSpeed = 0f;
            }

            if (zSpeed > 0f)
            {
                zSpeed -= .1f;
            }
            else if (zSpeed < -0.1f)
            {
                zSpeed += .1f;
            }
            else
            {
                zSpeed = 0f;
            }
        }

        rb.velocity = new Vector3(xSpeed, 0f,zSpeed);

        //Updating the player's direction if they are moving.
        if (moving) {
            heading = Mathf.Atan2(joystick.Horizontal, joystick.Vertical);
            this.transform.rotation = Quaternion.Euler(0f, heading * Mathf.Rad2Deg, 0f);
        }

        //Updating the state of animation of the player based on what is happening.

    }
}
