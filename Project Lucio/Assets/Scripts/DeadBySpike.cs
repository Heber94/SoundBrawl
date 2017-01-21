using UnityEngine;
using System.Collections;

public class DeadBySpike : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col)
	{

		if (col.gameObject.tag == "Player") {
			col.gameObject.SetActive (false);
		}
	}
}
