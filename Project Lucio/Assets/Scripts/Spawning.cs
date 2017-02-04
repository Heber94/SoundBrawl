using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    private float spawnLimitTime = 3f;

    private float[] currentSpawnTimes;
    
    public GameObject[] Targets;

    Transform[] spawn_Points;

    int random;
    // Use this for initialization
    void Start () {
        spawn_Points = gameObject.GetComponentsInChildren<Transform>();

        for (int i = 1; i < spawn_Points.Length; i++)
        {
            if (i -1 < Targets.Length)
            {
                Targets[i - 1].transform.position = spawn_Points[i].transform.position;
                Targets[i - 1].SetActive(true);
            }
            
        }
        currentSpawnTimes = new float[Targets.Length];
        for(int i = 0; i < Targets.Length; i++)
        {
            currentSpawnTimes[i] = 0;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        
        for (int i = 0; i < Targets.Length; i++)
        {
            
            if (Targets[i].activeSelf == false)
            {
                currentSpawnTimes[i] += Time.deltaTime;
                if (currentSpawnTimes[i] >= spawnLimitTime)
                {
                    random = (int)Random.Range(1f, 5f);
                    continueSpawn(Targets[i]);
                    currentSpawnTimes[i] = 0f;
                }
            }
        }
    }
    


   
    private void continueSpawn(GameObject target)
    {

        target.SetActive(true);
        target.transform.position = spawn_Points[random].transform.position;
        target.GetComponent<Rigidbody>().velocity = Vector3.zero;
        
    }


}
