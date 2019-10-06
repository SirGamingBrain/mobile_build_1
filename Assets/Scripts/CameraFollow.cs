using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera main;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        main = this.GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //this.transform.Rotate();
        this.transform.LookAt(player.transform);
        //this.transform.position = new Vector3(player.transform.position.x,4.5f, player.transform.position.z);
    }
}
