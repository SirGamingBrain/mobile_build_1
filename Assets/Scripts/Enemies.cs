using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject [] EnemyTypes= new GameObject [3];
   
    GameObject GameController;
    GameObject Player;


    int moveSpeed = 3;
    int MaxDist = 6;
    int MinDist = 1;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        Player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

        CheckPosition();
        AiBehaviors();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void CheckPosition()
    {
        for (int i = 0; i < EnemyTypes.Length - 1; i++)
        {
            GameObject enemy1 = EnemyTypes[i];
            for (int j = i + 1; j < EnemyTypes.Length; j++)
            {
                GameObject enemy2 = EnemyTypes[i];
            }
        }
    }

    void AiBehaviors()
    {
        if (gameObject.name == "Enemy Type 1(Clone)")
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                transform.LookAt(Player.transform.position);
                if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                }

                if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
                {
                    //attack
                }
            }
           
        }

        if (gameObject.name == "Enemy Type 2(Clone)")
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                transform.LookAt(Player.transform.position);
                if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                }

                if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
                {
                    //attack
                }
            }
           
        }

        if (gameObject.name == "Enemy Type 3(Clone)")
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                transform.LookAt(Player.transform.position);
                if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                }

                if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
                {
                    //attack
                }
            }
           
        }

        if (gameObject.name == "Enemy Type 4(Clone)")
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                transform.LookAt(Player.transform.position);
                if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                }

                if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
                {
                    //attack
                }
            }
           
        }
    }
}
