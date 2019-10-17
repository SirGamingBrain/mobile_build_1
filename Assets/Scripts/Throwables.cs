using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{

    float moveSpeed = 10f;

    Rigidbody bulletrb;

    GameObject target;

    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        bulletrb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        transform.LookAt(target.transform.position);
        transform.Rotate(-95f, transform.rotation.y, transform.rotation.z, Space.Self);
        bulletrb.velocity = new Vector3(moveDirection.x, -1, moveDirection.z);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player")|| other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
