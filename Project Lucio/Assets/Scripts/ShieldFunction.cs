using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFunction : MonoBehaviour {

    public string prefix;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = GetComponentInParent<Transform>().position;
        transform.localPosition = GetComponentInParent<Transform>().localPosition;
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("collision");
        //Debug.Log(prefix);
        //If our shield touches any collider, we decide...
        //foreach (Collider col in colliders)
        //{
        //If a player try to come close to us, it's bounced (just a little, not like the waves)
        //if (col.gameObject.tag == "Player" && col.transform.position != gameObject.GetComponentInParent<Transform>().position)
        //{
        //    col.gameObject.GetComponent<Rigidbody>().AddForce(-(gameObject.transform.position - col.transform.position), ForceMode.Impulse);
        //    Debug.Log("player");
        //}
        //If our shield touch a wave, that one is destroyed
        if (col.gameObject.tag == "Wave")
        {
            Destroy(col.gameObject);
            Debug.Log("wave");
        }else if (col.gameObject.tag == "Shield" && col.gameObject.name != (prefix.ToString() + "Shield"))
        {
            col.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Debug.Log("shield");
        }
        //}
    }
}
