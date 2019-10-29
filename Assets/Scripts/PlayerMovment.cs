using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    public AudioSource playerSounds;

    public AudioClip dodge;
    public AudioClip attack;
    public AudioClip ouch;
    public AudioClip die;

    Button attackButton;

    Image health;

    Rigidbody rb;

    public Collider sword;

    Animator ninja;

    Vector3 forwardVel;
    Vector3 horizontalVel;

    protected Joystick joystick;

    bool moving = false;
    bool attacking = false;
    bool blocking = false;
    bool hurting = false;
    public bool dead = false;

    float xSpeed = 0f;
    float zSpeed = 0f;
    float heading = 0f;
    float tempHeading = 0f;
    float dCenter = 0f;

    public float currentHealth = 5;
    readonly float maxHealth = 5;

    float debugTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        joystick = FindObjectOfType<Joystick>();

        attackButton = GameObject.Find("Attack").GetComponent<Button>();

        ninja = GetComponent<Animator>();
        sword.enabled = false;

        health = GameObject.Find("Health").GetComponent<Image>();
        health.fillAmount = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(new Vector3 (0f,1.5f,0f));

        //A timer to debug all of the things that I need to track.
        debugTimer += Time.deltaTime;

        dCenter = Vector3.Distance(new Vector3(0, 1.5f, 0f), transform.position);
        if (currentHealth > 0f)
        {
            if (debugTimer >= 5f)
            {
                //Debug.Log("Moving: " + moving);
                //Debug.Log("Horizontal Speed: " + xSpeed);
                //Debug.Log("Vertical Speed: " + zSpeed);
                Debug.Log("Distance to Center: " + dCenter);
                debugTimer = 0f;
            }

            //Checking to see if the player is moving, and updating some animations.

            if ((joystick.Horizontal == 0 && joystick.Vertical == 0) || (attacking || blocking) || (ninja.GetBool("Attacking")))
            {
                moving = false;
                ninja.SetBool("Running", false);
            }
            else
            {
                moving = true;
                ninja.SetBool("Running", true);
                ninja.SetBool("Attacking", false);
                ninja.SetBool("Blocking", false);
            }

            //Updating the player's speed and direction of movement if they are moving, otherwise slow them overtime.
            if (moving == true)
            {
                xSpeed = joystick.Horizontal * 5f;
                zSpeed = joystick.Vertical * 5f;

                /*if (dCenter <= 2f)
                {
                    zSpeed = 0f;
                }*/
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

            //Updating the player's direction based on movement.
            if (moving)
            {
                heading = Mathf.Atan2(joystick.Horizontal, joystick.Vertical);
                tempHeading = heading;
            }

            transform.Rotate(0f, tempHeading * Mathf.Rad2Deg, 0f, Space.Self);

            //Updating the state of animation of the player based on what is happening.
            if (blocking == true)
            {
                rb.velocity = (transform.forward * 7.5f);
            }
        }
        else
        {
            ninja.SetBool("Dead", true);
        }
    }

    public void Update()
    {
        if (attacking == true)
        {
            attackButton.enabled = false;
        }
        else
        {
            attackButton.enabled = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && !blocking)
        {
            Debug.Log("I've been hit!");

            if (currentHealth > 0f && !ninja.GetBool("Hurt"))
            {
                currentHealth -= 1;
                health.fillAmount = currentHealth / maxHealth;
                hurting = true;
                playerSounds.clip = ouch;
                playerSounds.Play();
                if (currentHealth == 0f)
                {
                    ninja.SetBool("Dead", true);
                }
                else
                {
                    ninja.SetBool("Hurt", true);
                }
            }
        }
    }

    public void AttackEnd()
    {
        attacking = false;
    }

    public void Hit()
    {
        sword.enabled = false;
        attacking = false;
        ninja.SetBool("Attacking", false);
    }

    public void AttackButton()
    {
        if (!ninja.GetBool("Attacking") && attacking == false) {
            sword.enabled = true;
            playerSounds.clip = attack;
            playerSounds.Play();
            attacking = true;
            ninja.SetBool("Attacking", true);
        }
        else
        {
            ninja.SetBool("Attacking", false);
        }
    }

    public void Block()
    {
        blocking = false;
        ninja.SetBool("Blocking", false);
    }

    public void BlockButton()
    {
        playerSounds.clip = dodge;
        playerSounds.Play();
        blocking = true;
        ninja.SetBool("Blocking", true);
    }

    public void Hurt()
    {
        hurting = false;
        ninja.SetBool("Hurt", false);
    }

    public void DeathOver()
    {
        dead = true;
    }
}
