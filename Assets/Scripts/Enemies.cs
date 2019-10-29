using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject [] EnemyTypes= new GameObject [3];
   
    GameObject GameController;
    GameObject Player;

    [SerializeField]
    GameObject throwable;

    Collider hitbox;
    
    GameObject [] OtherEnemy;

    readonly Transform[] PlayerPos;

    public GameObject weaponSpawn;
    Collider fistBox;

    Rigidbody rb;

    Animator enemyAnimator;

    readonly int moveSpeed = 3;
    readonly int maxspeed = 5;
   
    readonly int MaxDist = 6;
    readonly int MinDist = 2;
    readonly int MeleeMinDist = 1;
    readonly int MeleeMaxDist = 6;
    readonly int ArcherMinDist = 5;
    readonly int ArcherMaxDist = 10;
    readonly int ThrowerMaxDist = 4;
    readonly int ThrowerMinDist = 2;

    //float force = 5f;
    float distance =  10;
    float UpdatePos;
    readonly float BackPeddle = 1.5f;
    readonly float ArcherRate = 2.5f;
    readonly float ThrowerRate = .5f;
    float nextShot;
    float deathTimer = 0f;

    Vector3 lastPos;
    Vector3 PlayerLastMove;
    Vector3 moveAway;

    readonly bool isallowed;
    bool isDead;
    

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        Player = GameObject.FindWithTag("Player");
        OtherEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        rb = GetComponent<Rigidbody>();
        PlayerLastMove = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        nextShot = Time.deltaTime;
        enemyAnimator = this.GetComponent<Animator>();
        weaponSpawn = GameObject.Find("Bip02 R Hand");
        hitbox = GetComponent<Collider>();

        if (gameObject.name == "Enemy Type 1(Clone)")
        {
            fistBox = GetComponentInChildren<BoxCollider>();
            fistBox.enabled = false;
        }      
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isDead)
        {
            deathTimer += Time.deltaTime;

            if (deathTimer > 3f)
            {
                Destroy(gameObject);
            }
        }

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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Katana"))
        {
            if (gameObject.name == "Enemy Type 2(Clone)")
            {
                //hitbox.isTrigger = true;
            }
            else
            {
                hitbox.enabled = false;
            }
            
            enemyAnimator.SetBool("Dead", true);
            isDead = true;
        }
    }

    void AiBehaviors()
    {
        float dist;
       // handles moving towards the player for each type of enemy so we can have different animations and sound tied to the different types

       //Peasant Melee Behaviors
        if (gameObject.name == "Enemy Type 1(Clone)" && !isDead)
        {
            dist = Vector3.Distance(transform.position, Player.transform.position);

            if (dist > MeleeMinDist && !isDead)
            {
                enemyAnimator.SetBool("Moving", true);
                enemyAnimator.SetBool("Attacking", false);
                //Vector3 PlayerLastMove = Player.transform.position;
                //Debug.Log(PlayerLastMove + " last store move");
                Vector3 newPos = Vector3.MoveTowards(transform.position, Player.transform.position, 3f * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, newPos, 3f);
                transform.LookAt(Player.transform);
                //transform.Translate(PlayerLastMove, Space.Self);
            }
            else if (dist < MeleeMinDist && !isDead)
            {
                enemyAnimator.SetBool("Moving", false);
                enemyAnimator.SetBool("Attacking", true);
                fistBox.enabled = true;
                transform.LookAt(Player.transform);
                //attack
            }
        }
        else
        {
            transform.position = this.transform.position;
        }

        //Spear Thrower Behaviors
        if (gameObject.name == "Enemy Type 2(Clone)" && !isDead)
        {
           
                dist = Vector3.Distance(transform.position, Player.transform.position);
                
                if (dist <= ArcherMinDist && !isDead)
                {
                transform.LookAt(Player.transform.position);
                enemyAnimator.SetBool("Running", false);
                transform.position -= transform.forward* BackPeddle * Time.deltaTime;
                }
                else if (dist < ArcherMaxDist && dist > ArcherMinDist && !isDead)
                {
                enemyAnimator.SetBool("Running", false);
                //attack 2 
                nextShot += Time.deltaTime;
                if (nextShot >= ArcherRate && !isDead)
                {
                    transform.LookAt(Player.transform.position);
                    enemyAnimator.SetBool("Attacking", true);
                }
 
                }
                else if (dist > ArcherMaxDist && !isDead)
                {
                    enemyAnimator.SetBool("Running", true);
                    transform.LookAt(Player.transform.position);
                    transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
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
                        //moveAway = (this.transform.position - e.transform.position).normalized;
                        //rb.velocity = -moveAway * moveSpeed;
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
        else
        {
            transform.position = this.transform.position;
        }

        //F
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
                        //moveAway = (this.transform.position - e.transform.position).normalized;
                        //rb.velocity = -moveAway * moveSpeed;
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

        //F
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
                        //moveAway = (this.transform.position - e.transform.position).normalized;
                        //rb.velocity = -moveAway * moveSpeed;
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

    public void Throw()
    {
        enemyAnimator.SetBool("Attacking", false);        
        Instantiate(throwable, weaponSpawn.transform.position, throwable.transform.rotation);
        nextShot = 0;
    }

    public void RunningEnd()
    {
        enemyAnimator.SetBool("Running", false);
    }

    public void FootL()
    {

    }

    public void FootR()
    {

    }

    public void Hit()
    {
        enemyAnimator.SetBool("Attacking", false);
        fistBox.enabled = false;
        //enemyAnimator.SetBool("Moving", true);
    }

    public void DeathOver()
    {

    }
}
