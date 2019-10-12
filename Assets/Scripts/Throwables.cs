using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{

    float moveSpeed = 7f;

    Rigidbody bulletrb;

    GameObject target;

    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        bulletrb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        bulletrb.velocity = new Vector3(moveDirection.x, 1, moveDirection.z);
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
