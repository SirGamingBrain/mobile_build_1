using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //use compare tag to check if there are any enemies in no enemies increase the wave count and start spawning
    public GameObject[] Enemies = new GameObject[4];
    public Transform[] spawnpoint = new Transform[3];

    public bool wavesComplete = false;

    int waveCounter = 0;
    readonly int Enemycounter;

    // Start is called before the first frame update
    void Start()
    {
        waveCounter = 1;
        StartCoroutine(WaveSpawning());
    }

    // Update is called once per frame
    void Update()
    { 
        //EnemiesGone();

        if (waveCounter == 5 && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            StopCoroutine(WaveSpawning());
            wavesComplete = true;
            Debug.Log("Onto the next level.");
        }

        //check to see if all the enmies have been killed and then increase the counter.
    }

    void WaveManagement()
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName("Level 1") )
        {
            if (waveCounter == 1 || waveCounter == 0)
            {
                Instantiate(Enemies[0], spawnpoint[2].position, spawnpoint[2].rotation);
            }
            else if (waveCounter == 2)
            {
                for(int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 0 || i == 2)
                    {
                        Instantiate(Enemies[0], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }
            else if (waveCounter == 3)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    Instantiate(Enemies[0], spawnpoint[i].position, spawnpoint[i].rotation);
                }
            }
            else if (waveCounter == 4)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 3)
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }
            else if (waveCounter == 5)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 3)
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                    else if (i == 2)
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }

            Debug.Log("This is Wave:" + " " + waveCounter);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2"))
        {
            if (waveCounter == 1 || waveCounter == 0)
            {
                Instantiate(Enemies[1], spawnpoint[0].position, spawnpoint[0].rotation);
                Instantiate(Enemies[1], spawnpoint[2].position, spawnpoint[2].rotation);
            }
            else if (waveCounter == 2)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 3)
                    {
                        Instantiate(Enemies[0], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                    else
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }
            else if (waveCounter == 3)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 3)
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                    else
                    {
                        Instantiate(Enemies[2], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }
            else if (waveCounter == 4)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }
            else if (waveCounter == 5)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                }
            }

            Debug.Log("This is Wave:" + " " + waveCounter);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 3"))
        {
            if (waveCounter == 1 || waveCounter == 0)
            {
                Instantiate(Enemies[0], spawnpoint[2].position, spawnpoint[2].rotation);
            }
            else if (waveCounter == 2)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 0 || i == 2)
                    {
                        Instantiate(Enemies[0], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }
            else if (waveCounter == 3)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    Instantiate(Enemies[0], spawnpoint[i].position, spawnpoint[i].rotation);
                }
            }
            else if (waveCounter == 4)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 3)
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }
            else if (waveCounter == 5)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 3)
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                    else if (i == 2)
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }

            Debug.Log("This is Wave:" + " " + waveCounter);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 4"))
        {
            if (waveCounter == 1 || waveCounter == 0)
            {
                Instantiate(Enemies[1], spawnpoint[0].position, spawnpoint[0].rotation);
                Instantiate(Enemies[1], spawnpoint[2].position, spawnpoint[2].rotation);
            }
            else if (waveCounter == 2)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 3)
                    {
                        Instantiate(Enemies[0], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                    else
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }
            else if (waveCounter == 3)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 3)
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                    else
                    {
                        Instantiate(Enemies[2], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }
            else if (waveCounter == 4)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                    }
                }
            }
            else if (waveCounter == 5)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    Instantiate(Enemies[1], spawnpoint[i].position, spawnpoint[i].rotation);
                }
            }

            Debug.Log("This is Wave:" + " " + waveCounter);
        }

    }

    IEnumerator WaveSpawning()
    {
           
        while (true)
        {
            //Debug.Log("The next wave:" + " " + waveCounter);
            if (GameObject.FindGameObjectWithTag("Enemy") != null)
            {
                yield return true;
            }
            else
            {
                yield return new WaitForSeconds(3);
                WaveManagement();
                waveCounter++;
            }
        }
           
    }
}
