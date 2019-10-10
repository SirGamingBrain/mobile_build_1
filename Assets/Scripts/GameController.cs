using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //use compare tag to check if there are any enemies in no enemies increase the wave count and start spawning
    public GameObject[] Enemies = new GameObject[4];
    public Transform[] spawnpoint = new Transform[3];

    int waveCounter = 0;
    int Enemycounter;

    // Start is called before the first frame update
    void Start()
    {
        waveCounter = 1;
        StartCoroutine(waveSpawning());
    }

    // Update is called once per frame
    void Update()
    { 
        EnemiesGone();

        if (waveCounter == 5)
        {
            StopCoroutine(waveSpawning());
            Debug.Log("Game is finished");
        }

        //check to see if all the enmies have been killed and then increase the coutner
    }

    void WaveManagement()
    {
       
        if (waveCounter == 1 )
        {
            for(int i = 0; i<spawnpoint.Length-1; i++)
            {
                Instantiate(Enemies[0], spawnpoint[i].position, spawnpoint[i].rotation);
                //spawn an enemy
                Debug.Log("this the spawnpoints"+ " " + spawnpoint[i]);
                if (spawnpoint[i] == spawnpoint[1])
                {
                    i++;
                    Debug.Log(spawnpoint[i]);
                    //spawn stronger enemy
                    Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);

                }
            }
            Debug.Log("This is Wave:" + " " + waveCounter);

        }

        if (waveCounter == 2)
        {
            for (int i = 0; i < spawnpoint.Length - 1; i++)
            {
                Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                //spawn an enemy
                Debug.Log("this the spawnpoints" + " " + spawnpoint[i]);
                if (spawnpoint[i] == spawnpoint[1])
                {
                    i++;
                    Debug.Log(spawnpoint[i]);
                    //spawn stronger enemy
                    Instantiate(Enemies[2], spawnpoint[i].position, spawnpoint[i].rotation);

                }
            }
            Debug.Log("This is Wave:" + " " + waveCounter);
        }

        if (waveCounter == 3)
        {
            for (int i = 0; i < spawnpoint.Length - 1; i++)
            {
                Instantiate(Enemies[2], spawnpoint[i].position, spawnpoint[i].rotation);
                //spawn an enemy
                Debug.Log("this the spawnpoints" + " " + spawnpoint[i]);
                if (spawnpoint[i] == spawnpoint[1])
                {
                    i++;
                    Debug.Log(spawnpoint[i]);
                    //spawn stronger enemy
                    Instantiate(Enemies[3], spawnpoint[i].position, spawnpoint[i].rotation);

                }
            }
            Debug.Log("This is Wave:" + " " + waveCounter);
        }

        if (waveCounter == 4 )
        {
            for (int i = 0; i < spawnpoint.Length - 1; i++)
            {
                Instantiate(Enemies[3], spawnpoint[i].position, spawnpoint[i].rotation);
                //spawn an enemy
                Debug.Log("this the spawnpoints" + " " + spawnpoint[i]);
                if (spawnpoint[i] == spawnpoint[1])
                {
                    i++;
                    Debug.Log(spawnpoint[i]);
                    //spawn stronger enemy
                    Instantiate(Enemies[3], spawnpoint[i].position, spawnpoint[i].rotation);

                }
            }
            Debug.Log("This is Wave:" + " " + waveCounter);

        }

    }

    void EnemiesGone()
    {
        //all the enemies are dead then increment wave counter
        if (Enemycounter == 3)
        {
            //all the enemies are killed you can now increment the waves manager
            waveCounter++;
            StartCoroutine(waveSpawning());
            Debug.Log("This is the next Wave:" + "" + waveCounter);
        }
    }

   

    IEnumerator waveSpawning()
    {
           
        while (true)
        {
            Debug.Log("The next wave:" + " " + waveCounter);
            if (GameObject.FindGameObjectWithTag("Enemy") != null)
            {
                yield return true;
            }

            else
            {
                yield return new WaitForSeconds(3);
                WaveManagement();
                waveCounter++;
                Debug.Log("Am i here?");
               
            }
        }
           
    }
}
