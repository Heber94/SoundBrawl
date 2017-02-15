using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    public float score = 0;
    public float mass = 10;
    //sounds
    public AudioClip[] ScreamTypes;
    AudioSource audio;



    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Scream()
    {
        if (ScreamTypes.Length > 0)
        {
            AudioClip clip = ScreamTypes[UnityEngine.Random.Range(0, ScreamTypes.Length)];
            audio.clip = clip;
            audio.Play();
        }

    }

}
