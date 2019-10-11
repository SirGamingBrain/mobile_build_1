using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject [] EnemyTypes= new GameObject [3];
   
    GameObject GameController;
    GameObject Player;
    GameObject OtherEnemy;

    Rigidbody rb;

    int moveSpeed = 3;
    int MaxDist = 6;
    int MinDist = 2;
    int EnemyMinDist = 2;
    int EnemyMaxDist = 6;

    float force = 5f;
    float distance;
    float attackTimer;

    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        Player = GameObject.FindWithTag("Player");
        OtherEnemy = GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, OtherEnemy.transform.position);
       
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

        if (GameObject.ReferenceEquals(this.gameObject, OtherEnemy.gameObject))
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

            
           
        }

    }

    void AiBehaviors()
    {
        float dist;
        //handles moving towards the player for each type of enemy so we can have different animations and sound tied to the different types
        if (gameObject.name == "Enemy Type 1(Clone)")
        {
            dist = Vector3.Distance(transform.position, Player.transform.position);
            if (dist < MaxDist && dist > MinDist)
            {
                transform.LookAt(Player.transform.position);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;

            }
            else if (dist < MinDist)
            {
                Debug.Log("attack");
                //attack
            }
            else if (dist > MaxDist)
            {
                //stand still
            }

            if (this.gameObject.GetInstanceID() == OtherEnemy.gameObject.GetInstanceID())
            {
                Debug.Log("we cooling bro");
            }

            if (this.gameObject.GetInstanceID() != OtherEnemy.gameObject.GetInstanceID())
            {
                Debug.Log("we gotta separate bro");
                if (distance <= EnemyMinDist)
                {
                    transform.position = new Vector3(OtherEnemy.transform.position.x + 6, OtherEnemy.transform.position.y, OtherEnemy.transform.position.z + 6);
                    //transform.position = (transform.position - OtherEnemy.transform.position).normalized * EnemyMaxDist + OtherEnemy.transform.position;

                }
            }

        }

        if (gameObject.name == "Enemy Type 2(Clone)")
        {
            dist = Vector3.Distance(transform.position, Player.transform.position);
            if (dist < MaxDist && dist > MinDist)
            {
                transform.LookAt(Player.transform.position);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
           
            }
            else if (dist < MinDist)
            {
                Debug.Log("attack");
                //attack
            }
            else if (dist > MaxDist)
            {
                //stand still
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



            }

        }

        if (gameObject.name == "Enemy Type 3(Clone)")
        {
            dist = Vector3.Distance(transform.position, Player.transform.position);
            if (dist < MaxDist && dist > MinDist)
            {
                transform.LookAt(Player.transform.position);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
             
            }
           else if (dist < MinDist)
            {
                Debug.Log("attack");
                //attack
            }
            else if (dist > MaxDist)
            {
                //stand still
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



            }

        }

        if (gameObject.name == "Enemy Type 4(Clone)")
        {
            dist = Vector3.Distance(transform.position, Player.transform.position);
            if (dist < MaxDist && dist > MinDist)
            {
                transform.LookAt(Player.transform.position);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
        
            }

           else  if (dist < MinDist)
            {
                Debug.Log("attack");
                //attack
            }
            else if (dist > MaxDist)
            {
                //stand still
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



            }

        }
    }


    
}
