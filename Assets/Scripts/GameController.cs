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

    public bool isSpawned;

    // Start is called before the first frame update
    void Start()
    {
        waveCounter = 1;
        isSpawned = true;
        WaveManagement();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
        EnemiesGone();
        Debug.Log(Enemycounter);

        //check to see if all the enmies have been killed and then increase the coutner
    }

    void WaveManagement()
    {
       
        if (waveCounter == 1 && isSpawned)
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

           
        }

        if (waveCounter == 2 && isSpawned)
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
           
        }

        if (waveCounter == 3 && isSpawned)
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
           
        }

        if (waveCounter == 4 && isSpawned)
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

            isSpawned = false;
        }

       
    }

    void EnemiesGone()
    {
        //all the enemies are dead then increment wave counter
        if (Enemycounter == 3)
        {
            //all the enemies are killed you can now increment the waves manager
            waveCounter++;
            isSpawned = true;
            StartCoroutine(waveSpawning());
            Debug.Log("This is the next Wave:" + "" + waveCounter);
            Enemycounter = 0;

        }
    }

    void EnemyNumber()
    {
        Enemycounter = 3;
        Debug.Log("this the enemies:" + " " + Enemycounter);
        

    }

    IEnumerator waveSpawning()
    {
        yield return new WaitForSeconds(3);
        WaveManagement();
        Debug.Log("Am i here?");
        isSpawned = false;
    }
}
