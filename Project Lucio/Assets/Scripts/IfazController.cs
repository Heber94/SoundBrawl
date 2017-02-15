using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfazController : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    public Text tp1;
    public Text tp2;
    public Text tp3;
    public Text tp4;

    public Text remainingTime;





    // Update is called once per frame
    void Update()
    {
        //Actializa las puntuaciones en los marcadores
        tp1.text = p1.GetComponent<Player>().score.ToString();
        tp2.text = p2.GetComponent<Player>().score.ToString();
        tp3.text = p3.GetComponent<Player>().score.ToString();
        tp4.text = p4.GetComponent<Player>().score.ToString();

        float time = FindObjectOfType<GameOverManager>().remainingTime;
        remainingTime.text = (time/60).ToString("00") +":" + (time%60).ToString("00");

    }
}
