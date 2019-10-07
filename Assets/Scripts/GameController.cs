using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] Enemies = new GameObject[4];
    public Transform[] spawnpoint = new Transform[3];

    int waveCounter = 0;

    public bool isSpawned;

    // Start is called before the first frame update
    void Start()
    {
        waveCounter = 1;
    }

    private void Awake()
    {
        WaveManagement();
    }

    // Update is called once per frame
    void Update()
    {
       
       
        //check to see if all the enmies have been killed and then increase the coutner
    }

    void WaveManagement()
    {
        isSpawned = true;
        if (waveCounter == 1)
        {
            for(int i = 0; i<spawnpoint.Length-1; i++)
            {
                Instantiate(Enemies[0], spawnpoint[i].position, spawnpoint[i].rotation);
                //spawn an enemy
                Debug.Log(spawnpoint[i]);
                if (spawnpoint[i] == spawnpoint[1])
                {
                    i++;
                    Debug.Log(spawnpoint[i]);
                    //spawn stronger enemy
                    Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);

                }
            }
           


            isSpawned = false;
        }

        if (waveCounter == 2)
        {
            for (int i = 0; i < spawnpoint.Length - 1; i++)
            {
                Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                //spawn an enemy
                Debug.Log(spawnpoint[i]);
                if (spawnpoint[i] == spawnpoint[1])
                {
                    i++;
                    Debug.Log(spawnpoint[i]);
                    //spawn stronger enemy
                    Instantiate(Enemies[2], spawnpoint[i].position, spawnpoint[i].rotation);

                }
            }
            isSpawned = false;
        }

        if (waveCounter == 3)
        {
            for (int i = 0; i < spawnpoint.Length - 1; i++)
            {
                Instantiate(Enemies[2], spawnpoint[i].position, spawnpoint[i].rotation);
                //spawn an enemy
                Debug.Log(spawnpoint[i]);
                if (spawnpoint[i] == spawnpoint[1])
                {
                    i++;
                    Debug.Log(spawnpoint[i]);
                    //spawn stronger enemy
                    Instantiate(Enemies[3], spawnpoint[i].position, spawnpoint[i].rotation);

                }
            }
            isSpawned = false;
        }

        if (waveCounter == 4)
        {
            for (int i = 0; i < spawnpoint.Length - 1; i++)
            {
                Instantiate(Enemies[3], spawnpoint[i].position, spawnpoint[i].rotation);
                //spawn an enemy
                Debug.Log(spawnpoint[i]);
                if (spawnpoint[i] == spawnpoint[1])
                {
                    i++;
                    Debug.Log(spawnpoint[i]);
                    //spawn stronger enemy
                    Instantiate(Enemies[4], spawnpoint[i].position, spawnpoint[i].rotation);

                }
            }
            isSpawned = false;

        }


    }
}
