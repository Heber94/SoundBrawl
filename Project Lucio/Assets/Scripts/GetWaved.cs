using UnityEngine;
using System.Collections;

public class GetWaved : MonoBehaviour
{



    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //rb.AddForce(-5, 5, 0, ForceMode.Impulse);
    void OnCollisionEnter(Collision c)
    {
        // force is how forcefully we will push the player away from the enemy.
        float force = 0;



        // If the object we hit is the enemy
        if (c.gameObject.tag == "Wave")
        {
            if (c.gameObject.name.Contains(gameObject.name))
            {
                Physics.IgnoreCollision(c.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);
            }
            else
            {
                force = Mathf.Clamp(c.gameObject.transform.localScale.y, 100, 200);
                Vector3 dir = c.gameObject.transform.position - transform.position;
                // We then get the opposite (-Vector3) and normalize it
                dir = -dir.normalized;
                // And finally we add force in the direction of dir and multiply it by force. 
                // This will push back the player
                rb.AddForce(dir * force, ForceMode.Impulse);
            }
        }

    }
}
