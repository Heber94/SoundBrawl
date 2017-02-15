using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{
    public float remainingTimeInMin = 4;
    [HideInInspector]
    public float remainingTime;

    public Text p1;
    public Text p2;
    public Text p3;
    public Text p4;

    public GameObject gameoverScreen;
    public Text finalScoreA;
    public Text finalScoreB;


    void Start()
    {
        remainingTime = remainingTimeInMin * 60;
    }


    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime < 0)
        {
            Time.timeScale = 0;
            gameoverScreen.SetActive(true);
            finalScoreA.text = ("Player 1: " + p1.text + "      Player 2: " + p2.text);
            finalScoreB.text = ("Player 3: " + p3.text + "      Player 4: " + p4.text);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }
}
