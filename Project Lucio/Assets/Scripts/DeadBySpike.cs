using UnityEngine;
using System.Collections;

public class DeadBySpike : MonoBehaviour {


    AudioSource audioSource;
    public AudioClip[] gritos;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col)
	{
        AudioClip grito = gritos[Random.Range(0, gritos.Length-1)];


		if (col.gameObject.tag == "Player") {
            audioSource.clip = grito;
            audioSource.Play();
			col.gameObject.SetActive (false);
		}
	}
}
