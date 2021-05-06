using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleStartPosition : MonoBehaviour
{

    private Rigidbody rb;

    private AudioSource audiosrc;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosrc = GetComponent<AudioSource>();

        rb.AddForce(Random.Range(-5, 5), 0, 0);
        transform.position = new Vector3(Random.Range(-5, 5), transform.position.y, transform.position.z);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Player")
        {
            audiosrc.Play();

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
