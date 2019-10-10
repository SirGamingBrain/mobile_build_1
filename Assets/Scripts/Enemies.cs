using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
   
    float enemyHP = 100;
    GameObject GameController;

    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onDeath();
        }
        
    }

    void onDeath()
    {
        Destroy(this.gameObject);
        GameController.SendMessage("EnemiesNumber", SendMessageOptions.DontRequireReceiver);
    }
}
