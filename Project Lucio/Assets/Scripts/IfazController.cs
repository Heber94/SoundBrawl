using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfazController : MonoBehaviour {


    public PlayerController p1;
    public PlayerController p2;
    public PlayerController p3;
    public PlayerController p4;

    public Text tp1;
    public Text tp2;
    public Text tp3;
    public Text tp4;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        tp1.text = p1.score.ToString();
        tp2.text = p2.score.ToString();
        tp3.text = p3.score.ToString();
        tp4.text = p4.score.ToString();



    }
}
