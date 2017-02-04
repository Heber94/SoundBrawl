using UnityEngine;
using System.Collections;

public class DeadBySpike : MonoBehaviour {


    AudioSource audioSource;
    public AudioClip[] gritos;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}


	void OnCollisionEnter(Collision col)
	{
        
        AudioClip grito = gritos[Random.Range(0, gritos.Length)];


		if (col.gameObject.tag == "Player") {
            PlayerController sc = col.gameObject.GetComponent<PlayerController>();
            sc.score += 1;
            audioSource.clip = grito;
            audioSource.Play();
			col.gameObject.SetActive (false);
		}
	}
}
