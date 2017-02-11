using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeScript : MonoBehaviour {
    public static int nJugadores;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        
    }

    // Update is called once per frame
    void Update () {
    }

    public void chooseMode(int nPlayers)
    {
        PlayerPrefs.SetInt("NPlayers", nPlayers);
        SceneManager.LoadScene("Level1");
    }
}
