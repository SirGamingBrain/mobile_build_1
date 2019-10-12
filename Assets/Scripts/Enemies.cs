using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject [] EnemyTypes= new GameObject [3];
   
    GameObject GameController;
    GameObject Player;
    GameObject [] OtherEnemy;

    Rigidbody rb;

    int moveSpeed = 3;
   
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

    Vector3 lastPos;
    Vector3 PlayerLastMove;
    Vector3 moveAway;

    

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        Player = GameObject.FindWithTag("Player");
        OtherEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        rb = GetComponent<Rigidbody>();
        PlayerLastMove = Player.transform.position;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdatePos += Time.deltaTime;
        if (UpdatePos >= 3)
        {
            PlayerLastMove = Player.transform.position;
            UpdatePos = 0;

        }
        Debug.Log(PlayerLastMove + "last Player pos");
        //e = GameObject.FindGameObjectsWithTag("Enemy");
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

   void CollisionDetection()
    {
        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, Vector3.left, out hit, 1000))
        //{

        //    if (hit.collider.gameObject.CompareTag("Enemy"))
        //    {
        //        Debug.Log("There is an enemy already there");
        //        if (hit.distance <= EnemyMinDist)
        //        {
        //            Vector3 direction = this.transform.position - OtherEnemy.transform.position;
        //            direction.y = 0;
        //            //transform.Translate(direction.normalized * (force * Time.deltaTime));
        //            transform.position = (transform.position - OtherEnemy.transform.position).normalized * EnemyMaxDist + OtherEnemy.transform.position;
        //            Debug.Log("New Pos:" + " " + transform.position + " " + hit.distance);

        //            if (distance != EnemyMaxDist)
        //            {
        //                Debug.Log("HEY MAN WE TOO CLOSE CAN YOU MOVE");
        //                direction = (this.transform.position - OtherEnemy.transform.position);
        //                direction.y = 0;
        //                transform.position = (transform.position - OtherEnemy.transform.position).normalized * EnemyMaxDist + OtherEnemy.transform.position;
        //                //transform.Translate(direction.normalized * (force * Time.deltaTime));
        //            }
        //        }

        //        else if (hit.distance > EnemyMaxDist)
        //        {
        //            Debug.Log("We shouldnt move");

        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        //else
        //{
        //    return false;
        //}

        //if (distance < EnemyMaxDist)
        //{
        //    Vector3 direction = this.transform.position - OtherEnemy.transform.position;
        //    direction.y = 0;
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 5 * Time.deltaTime);

        //    Debug.Log(distance);
        //    return true;
        //}

        //else
        //{
        //    return false;
        //}

        /*if (GameObject.ReferenceEquals(this.gameObject, OtherEnemy.gameObject))
        {
            Debug.Log("We da same");
            Debug.Log(this.gameObject.GetInstanceID() + " " + OtherEnemy.GetInstanceID());

        }

        else
        {
            Debug.Log("we aint the same");
            Debug.Log(this.gameObject.GetInstanceID() + " " + OtherEnemy.GetInstanceID());
        }

        if (this.gameObject.GetInstanceID() == OtherEnemy.gameObject.GetInstanceID())
        {
            Debug.Log("we cooling bro");
        }

        if (this.gameObject.GetInstanceID() != OtherEnemy.gameObject.GetInstanceID())
        {
            Debug.Log("we gotta separate bro");
            if (distance <= EnemyMaxDist)
            {
                transform.position = new Vector3(OtherEnemy.transform.position.x + 6, OtherEnemy.transform.position.y, OtherEnemy.transform.position.z + 6);
                //transform.position = (transform.position - OtherEnemy.transform.position).normalized * EnemyMaxDist + OtherEnemy.transform.position;

            }

            
           
        }*/

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
                    Debug.Log("attack");
                    //attack
            }
                
            foreach(GameObject e in OtherEnemy)
            {

                if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
                {
                    Debug.Log("we cooling bro of type 1");
                }

                else if (this.gameObject.GetInstanceID() != e.gameObject.GetInstanceID())
                {
                    
                   
                    if (distance <= MinDist)
                    {
                        Debug.Log("we gotta separate bro of type 1");

                        moveAway = (this.transform.position - e.transform.position).normalized;
                        rb.velocity = -moveAway * moveSpeed;



                    }

                    else if (distance >= MaxDist)
                    {
                        Debug.Log("we good bro type 1");
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
                    Debug.Log("attack 2");
                    //  attack
                }

            foreach (GameObject e in OtherEnemy)
            {
                if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
                {
                    Debug.Log("we cooling bro of type 2");
                }

                if (this.gameObject.GetInstanceID() !=e.gameObject.GetInstanceID())
                {
                    
                    if (distance <= MinDist)
                    {
                        Debug.Log("we gotta separate bro of type 2");
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
                Debug.Log("attack 3");
                //  attack
            }

            foreach (GameObject e in OtherEnemy)
            {
                if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
                {
                    Debug.Log("we cooling bro of type 3");
                }

                if (this.gameObject.GetInstanceID() != e.gameObject.GetInstanceID())
                {

                    if (distance <= MinDist)
                    {
                        Debug.Log("we gotta separate bro of type 3");
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
                transform.LookAt(Player.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);

            }
            else if (dist <= ThrowerMinDist)
            {

                transform.position -= transform.forward * 2.5f * Time.deltaTime;

            }
            else if (dist < ThrowerMaxDist && dist > ThrowerMinDist)
            {
                Debug.Log("attack 4");
                //  attack
            }

            foreach (GameObject e in OtherEnemy)
            {
                if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
                {
                    Debug.Log("we cooling bro of type 4");
                }

                if (this.gameObject.GetInstanceID() != e.gameObject.GetInstanceID())
                {

                    if (distance <= MinDist)
                    {
                        Debug.Log("we gotta separate bro of type 4");
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
