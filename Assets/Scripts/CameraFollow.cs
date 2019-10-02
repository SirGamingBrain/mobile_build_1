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
        player = GameObject.Find("Test Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate();
        this.transform.LookAt(player.transform);
    }
}
