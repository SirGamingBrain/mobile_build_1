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

    float force = 5f;
    float distance =  10;
    float MeleeAttackTimer;

    Vector3 lastPos;

    bool isAllowed;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        Player = GameObject.FindWithTag("Player");
        OtherEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
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

        Debug.Log("Minimum Distance: " + distance);


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
                if (dist < MeleeMaxDist && dist > MeleeMinDist)
                {
                    isAllowed = true;
                   
                    if (isAllowed)
                    {
                        Vector3 PlayerLastMove = Player.transform.position;
                        if (transform.position != PlayerLastMove)
                        {
                            //Vector3 PlayerLastMove = Player.transform.position;
                            transform.LookAt(PlayerLastMove);
                            Debug.Log(PlayerLastMove + " last store move");
                            Vector3 newPos = Vector3.MoveTowards(transform.position, PlayerLastMove, moveSpeed * Time.deltaTime);
                            transform.position = Vector3.Lerp(transform.position, newPos, moveSpeed * Time.deltaTime);
                            //transform.Translate(PlayerLastMove, Space.Self);
                            isAllowed = false;
                        }
                       
                    }
                   

                }
                else if (dist < MeleeMinDist)
                {
                    Debug.Log("attack");
                    isAllowed = false;
                    //attack
                }
                else if (dist > MeleeMaxDist)
                {
                    //stand still
                    isAllowed = false;
                }
            foreach (GameObject e in OtherEnemy)
            {

                if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
                {
                    Debug.Log("we cooling bro of type 1");
                }

                else if (this.gameObject.GetInstanceID() != e.gameObject.GetInstanceID())
                {
                    Debug.Log("we gotta separate bro of type 1");
                    if (distance <= MinDist)
                    {
                        transform.position = new Vector3(this.transform.position.x + 6, this.transform.position.y, this.transform.position.z + 6);
                        transform.position = (transform.position - e.transform.position).normalized * MaxDist + e.transform.position;

                    }

                    else if (distance >= MaxDist)
                    {
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
                else if (dist < ArcherMinDist)
                {
                    
                    transform.position -= transform.forward * moveSpeed * Time.deltaTime;
                    // attack
                }
                else if (dist < ArcherMaxDist && dist > ArcherMinDist)
                {
                    Debug.Log("attack");
                    //  stand still
                }

            foreach (GameObject e in OtherEnemy)
            {
                if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
                {
                    Debug.Log("we cooling bro of type 2");
                }

                if (this.gameObject.GetInstanceID() !=e.gameObject.GetInstanceID())
                {
                    Debug.Log("we gotta separate bro of type 2");
                    if (distance <= MinDist)
                    {
                        transform.position = new Vector3(this.transform.position.x - 6, this.transform.position.y, this.transform.position.z -6);
                        transform.position = (transform.position - e.transform.position).normalized * MaxDist + e.transform.position;

                    }
                    else if (distance >= MaxDist)
                    {
                        //stand still
                    }



                }
            }
            

        }

        //if (gameObject.name == "Enemy Type 3(Clone)")
        //{
        //    foreach (GameObject e in OtherEnemy)
        //    {
        //        dist = Vector3.Distance(transform.position, Player.transform.position);
        //        if (dist < MaxDist && dist > MinDist)
        //        {
        //            transform.LookAt(Player.transform.position);
        //            transform.position += transform.forward * moveSpeed * Time.deltaTime;

        //        }
        //        else if (dist < MinDist)
        //        {
        //            Debug.Log("attack");
        //            // attack
        //        }
        //        else if (dist > MaxDist)
        //        {
        //            // stand still
        //        }
        //        if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
        //        {
        //            Debug.Log("we cooling bro");
        //        }

        //        if (this.gameObject.GetInstanceID() != e.gameObject.GetInstanceID())
        //        {
        //            Debug.Log("we gotta separate bro");
        //            if (distance <= EnemyMaxDist)
        //            {
        //                transform.position = new Vector3(e.transform.position.x + 6, e.transform.position.y, e.transform.position.z + 6);
        //                transform.position = (transform.position - e.transform.position).normalized * EnemyMaxDist + e.transform.position;

        //            }



        //        }
        //    }


        //}

        //if (gameObject.name == "Enemy Type 4(Clone)")
        //{
        //    foreach (GameObject e in OtherEnemy)
        //    {
        //        dist = Vector3.Distance(transform.position, Player.transform.position);
        //        if (dist < MaxDist && dist > MinDist)
        //        {
        //            transform.LookAt(Player.transform.position);
        //            transform.position += transform.forward * moveSpeed * Time.deltaTime;

        //        }

        //        else if (dist < MinDist)
        //        {
        //            Debug.Log("attack");
        //            // attack
        //        }
        //        else if (dist > MaxDist)
        //        {
        //            // stand still
        //        }
        //        if (this.gameObject.GetInstanceID() == e.gameObject.GetInstanceID())
        //        {

        //            Debug.Log("we cooling bro");
        //        }

        //        if (this.gameObject.GetInstanceID() != e.gameObject.GetInstanceID())
        //        {
        //            Debug.Log("we gotta separate bro");
        //            if (distance <= EnemyMaxDist)
        //            {
        //                transform.position = new Vector3(e.transform.position.x + 6, e.transform.position.y, e.transform.position.z + 6);
        //                transform.position = (transform.position - e.transform.position).normalized * EnemyMaxDist + e.transform.position;

        //            }



        //        }
        //    }


        //}
    }



}
