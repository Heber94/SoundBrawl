using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {


	public float speed = 1f;
	Rigidbody body;
	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () 
	{
		float movespeed = Input.GetAxis ("Horizontal");
		float movespeedY = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (movespeed, movespeedY, 0f);
		body.velocity = movement * speed;
	}
}