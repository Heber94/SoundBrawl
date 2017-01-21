using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    
    public GameObject[] Targets;

    Transform[] spawn_Points;

    int random;
    // Use this for initialization
    void Start () {
        spawn_Points = gameObject.GetComponentsInChildren<Transform>();

        for (int i = 1; i < spawn_Points.Length; i++)
        {
            Targets[i-1].transform.position = spawn_Points[i].transform.position;
            Targets[i-1].SetActive(true);
        }

        
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject target in Targets)
        {

            if (target.activeSelf == false)
            {
                random = (int)Random.Range(1f, 5f);
                StartCoroutine("WaitRespawn", target);

            }
        }
    }
    
    IEnumerator WaitRespawn(GameObject target)
    {   
                yield return new WaitForSeconds(2f);
                continueSpawn(target);
    }

   
    private void continueSpawn(GameObject target)
    {

        target.SetActive(true);
        target.transform.position = spawn_Points[random].transform.position;
        target.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


}
