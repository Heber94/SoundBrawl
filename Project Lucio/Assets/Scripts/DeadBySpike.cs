using UnityEngine;
using System.Collections;

public class DeadBySpike : MonoBehaviour {

    //Cuando muere acciona el grito
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<Player>().Scream();
            ScoreController.AddScore(col.gameObject.GetComponent<Player>(), 1);
			col.gameObject.SetActive (false);
		}
	}
}
