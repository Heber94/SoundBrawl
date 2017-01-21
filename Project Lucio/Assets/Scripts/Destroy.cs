using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	float growSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){
		transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(transform.localScale.x + 1f,
			transform.localScale.y + 1f, transform.localScale.z + 1f), Time.deltaTime*growSpeed);
	}

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
