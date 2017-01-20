using UnityEngine;
using System.Collections;

public class GetWaved : MonoBehaviour {
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	//rb.AddForce(-5, 5, 0, ForceMode.Impulse);
	void OnCollisionEnter(Collision c)
	{
		// force is how forcefully we will push the player away from the enemy.
		float force = 5;

		// If the object we hit is the enemy
		if (c.gameObject.tag == "Wave")
		{
			// Calculate Angle Between the collision point and the player
			Vector3 dir = c.contacts[0].point - transform.position;
			// We then get the opposite (-Vector3) and normalize it
			dir = -dir.normalized;
			// And finally we add force in the direction of dir and multiply it by force. 
			// This will push back the player
			rb.AddForce(dir*force, ForceMode.Impulse);
		}
	}
}
