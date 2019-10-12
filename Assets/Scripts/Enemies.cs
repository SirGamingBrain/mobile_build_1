﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject [] EnemyTypes= new GameObject [3];
   
    GameObject GameController;
    GameObject Player;

    [SerializeField]
    GameObject throwable;
    
    GameObject [] OtherEnemy;

    Transform[] PlayerPos;

    Rigidbody rb;
   
    

    int moveSpeed = 3;
    int maxspeed = 5;
   
    int MaxDist = 6;
    int MinDist = 2;
    int MeleeMinDist = 2;
    int MeleeMaxDist = 6;
    int ArcherMinDist = 5;
    int ArcherMaxDist = 10;
    int ThrowerMaxDist = 4;
    int ThrowerMinDist = 2;

    //float force = 5f;
    float distance =  10;
    float UpdatePos;
    float BackPeddle = 1.5f;
    float ArcherRate = 1f;
    float ThrowerRate = .5f;
    float nextShot;

    Vector3 lastPos;
    Vector3 PlayerLastMove;
    Vector3 moveAway;

    bool isallowed;
    

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        Player = GameObject.FindWithTag("Player");
        OtherEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        rb = GetComponent<Rigidbody>();
        PlayerLastMove = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        nextShot = Time.deltaTime;
       
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        foreach (GameObject enemy in OtherEnemy)
        {
            if (enemy.gameObject != null)
            {
                float temp = Vector3.Distance(this.transform.position, enemy.transform.position);

                if (temp < distance && temp != 0)
                {
                    distance = temp;
                }
            }
           
        }

        //Debug.Log("Minimum Distance: " + distance);


        AiBehaviors();
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void AiBehaviors()
    {
        float dist;
       // handles moving towards the player for each type of enemy so we can have different animations and sound tied to the different types
       //Melee Behaviors
        if (gameObject.name == "Enemy Type 1(Clone)")
        {
                dist = Vector3.Distance(transform.position, Player.transform.position);
            if (dist > MeleeMaxDist || dist < MeleeMaxDist && dist > MeleeMinDist)
            {
               
                //Vector3 PlayerLastMove = Player.transform.position;
                //Debug.Log(PlayerLastMove + " last store move");
                Vector3 newPos = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, newPos, 3f);
                //transform.Translate(PlayerLastMove, Space.Self);
            }

            else if (dist < MeleeMinDist)
            {
                   
                    //attack
            }
                
            foreach(GameObject e in OtherEnemy)
            {

                if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
                {
                    //Debug.Log("we cooling bro of type 1");
                }

                else if (this.gameObject.GetInstanceID() != e.gameObject.GetInstanceID())
                {
                    
                   
                    if (distance <= MinDist)
                    {
                        //Debug.Log("we gotta separate bro of type 1");

                        moveAway = (this.transform.position - e.transform.position).normalized;
                        rb.velocity = -moveAway * moveSpeed;
                    }

                    else if (distance >= MaxDist)
                    {
                        //Debug.Log("we good bro type 1");
                        //stand still
                    }
                }

            }

        }

        //archer Behaviors
        if (gameObject.name == "Enemy Type 2(Clone)")
        {
           
                dist = Vector3.Distance(transform.position, Player.transform.position);
                if (dist > ArcherMaxDist)
                {
                    transform.LookAt(Player.transform.position);
                    transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);

                }
                else if (dist <= ArcherMinDist)
                {
                    
                    transform.position -= transform.forward* BackPeddle * Time.deltaTime;
                    
                }
                else if (dist < ArcherMaxDist && dist > ArcherMinDist)
                {
                   //attack 2 
                nextShot += Time.deltaTime;
                if (nextShot >= ArcherRate)
                {
                    Instantiate(throwable, transform.position, Quaternion.identity);
                    nextShot = 0;
                }
 
                }

            foreach (GameObject e in OtherEnemy)
            {
                if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
                {
                    //Debug.Log("we cooling bro of type 2");
                }

                if (this.gameObject.GetInstanceID() !=e.gameObject.GetInstanceID())
                {
                    
                    if (distance <= MinDist)
                    {
                        //Debug.Log("we gotta separate bro of type 2");
                        moveAway = (this.transform.position - e.transform.position).normalized;
                        rb.velocity = -moveAway * moveSpeed;
                        //transform.position = new Vector3(this.transform.position.x - 6, this.transform.position.y, this.transform.position.z -6);
                        //transform.position = (transform.position - e.transform.position).normalized * MaxDist + e.transform.position;

                    }
                    else if (distance >= MaxDist)
                    {
                        //stand still
                    }



                }
            }
            

        }

        //thrower
        if (gameObject.name == "Enemy Type 3(Clone)")
        {

            dist = Vector3.Distance(transform.position, Player.transform.position);
            if (dist > ThrowerMaxDist)
            {
                transform.LookAt(Player.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);

            }
            else if (dist <= ThrowerMinDist)
            {

                transform.position -= transform.forward * 2.5f * Time.deltaTime;

            }
            else if (dist < ThrowerMaxDist && dist > ThrowerMinDist)
            {
               //attack 3
                nextShot += Time.deltaTime;
                if (nextShot >= ThrowerRate)
                {
                    Instantiate(throwable, transform.position, Quaternion.identity);
                    nextShot = 0;
                }

                
            }

            foreach (GameObject e in OtherEnemy)
            {
                if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
                {
                    //Debug.Log("we cooling bro of type 3");
                }

                if (this.gameObject.GetInstanceID() != e.gameObject.GetInstanceID())
                {

                    if (distance <= MinDist)
                    {
                        //Debug.Log("we gotta separate bro of type 3");
                        moveAway = (this.transform.position - e.transform.position).normalized;
                        rb.velocity = -moveAway * moveSpeed;
                        //transform.position = new Vector3(this.transform.position.x - 6, this.transform.position.y, this.transform.position.z -6);
                        //transform.position = (transform.position - e.transform.position).normalized * MaxDist + e.transform.position;

                    }
                    else if (distance >= MaxDist)
                    {
                        //stand still
                    }



                }
            }



        }

        if (gameObject.name == "Enemy Type 4(Clone)")
        {

            dist = Vector3.Distance(transform.position, Player.transform.position);
            if (dist > ThrowerMaxDist)
            {
                //attack 4
                float ramSpeed = moveSpeed + (.5f * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, PlayerLastMove, ramSpeed * Time.deltaTime);
                //transform.LookAt(Player.transform.position);
                //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);

            }
            //else if (dist <= ThrowerMinDist)
            //{

            //    transform.position -= transform.forward * 2.5f * Time.deltaTime;

            //}
            //else if (dist < ThrowerMaxDist && dist > ThrowerMinDist)
            //{
            //    Debug.Log("attack 4");
            //    transform.position = Vector3.MoveTowards(transform.position, PlayerLastMove, moveSpeed * Time.deltaTime);
            //    //  attack
            //}

            if (transform.position == PlayerLastMove)
            {
                Debug.Log("I will stand still for a second");
                UpdatePos += Time.deltaTime;
               
                if (UpdatePos >= 1f)
                {
                    PlayerLastMove = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
                    UpdatePos = 0;
                }
            }

            foreach (GameObject e in OtherEnemy)
            {
                if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
                {
                    //Debug.Log("we cooling bro of type 4");
                }

                if (this.gameObject.GetInstanceID() != e.gameObject.GetInstanceID())
                {

                    if (distance <= MinDist)
                    {
                        //Debug.Log("we gotta separate bro of type 4");
                        moveAway = (this.transform.position - e.transform.position).normalized;
                        rb.velocity = -moveAway * moveSpeed;
                        //transform.position = new Vector3(this.transform.position.x - 6, this.transform.position.y, this.transform.position.z -6);
                        //transform.position = (transform.position - e.transform.position).normalized * MaxDist + e.transform.position;

                    }
                    else if (distance >= MaxDist)
                    {
                        //stand still
                    }



                }
            }

        }
    }
}
