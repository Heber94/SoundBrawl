using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    private float spawnLimitTime = 3f;

    private float[] currentSpawnTimes;
    
    public GameObject[] Targets;


    Transform[] spawn_Points;

    GameObject[] currentTargets;
    int random;

    int nPlayers;
    // Use this for initialization
    void Start () {
        spawn_Points = gameObject.GetComponentsInChildren<Transform>();
        //Receives number of players from the main menu
        nPlayers = PlayerPrefs.GetInt("NPlayers");
        currentTargets = new GameObject[nPlayers];
        //Only plays with the number of targets chosen
        for(int i = 0; i < nPlayers; i++)
        {
            currentTargets[i] = Targets[i];
        }
        //Deactivate the rest of the players
        for(int i = nPlayers; i < Targets.Length; i++)
        {
            Targets[i].SetActive(false);
        }
        for (int i = 1; i < spawn_Points.Length; i++)
        {
            if (i -1 < currentTargets.Length)
            {
                currentTargets[i - 1].transform.position = spawn_Points[i].transform.position;
                currentTargets[i - 1].SetActive(true);
            }
            
        }
        currentSpawnTimes = new float[currentTargets.Length];
        for(int i = 0; i < currentTargets.Length; i++)
        {
            currentSpawnTimes[i] = 0;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        
        for (int i = 0; i < currentTargets.Length; i++)
        {
            
            if (Targets[i].activeSelf == false)
            {
                //Time counter to control the spawn time limit
                currentSpawnTimes[i] += Time.deltaTime;
                if (currentSpawnTimes[i] >= spawnLimitTime)
                {
                    random = (int)Random.Range(1f, 5f);
                    continueSpawn(currentTargets[i]);
                    currentSpawnTimes[i] = 0f;
                }
            }
        }
    }
    


   //If the spawn limit time has passed, the player can spawn
    private void continueSpawn(GameObject target)
    {

        target.SetActive(true);
        target.transform.position = spawn_Points[random].transform.position;
        target.GetComponent<Rigidbody>().velocity = Vector3.zero;
        
    }


}
