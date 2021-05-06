
using UnityEngine;

public class BottleCollision : MonoBehaviour
{

    public float hitForce;
    private float delta;

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Bottle")
        {
            delta = collisionInfo.transform.position.x - transform.position.x;
            collisionInfo.rigidbody.AddForce(delta * 1000, Random.Range(-50, 50), hitForce);

        }

    }
}
