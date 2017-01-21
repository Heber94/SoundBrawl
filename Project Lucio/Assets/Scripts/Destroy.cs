using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float growSpeed = 2f;

	// Use this for initialization
	void Start () {
        Physics.IgnoreLayerCollision(8, 9);
        Physics.IgnoreLayerCollision(9, 9);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){
		transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(transform.localScale.x + 1f,
			transform.localScale.y + 1f, transform.localScale.z + 1f), Time.deltaTime * growSpeed);
	}

	void OnCollisionEnter(Collision c)
	{
        Debug.Log(c.gameObject.tag);
		if (c.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
