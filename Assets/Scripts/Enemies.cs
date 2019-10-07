using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
   
    float enemyHP = 100;

    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyHP = 0;
            isAlive = false;
            onDeath();
        }
        onDeath();
    }

    void onDeath()
    {
        if (!isAlive)
        {
            gameObject.SendMessage("EnemyNumber", SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
        }
    }
}
