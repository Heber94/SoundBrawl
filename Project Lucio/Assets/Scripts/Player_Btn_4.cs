using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Btn_4 : MonoBehaviour {

    public Sprite onMouseEnterSprite;
    public Sprite onClickSprite;
    Sprite previous;
    Image imagen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        imagen = gameObject.GetComponent<Image>();
        previous = imagen.sprite;
        
    }

    private void OnMouseEnter()
    {
        
       imagen.sprite = onMouseEnterSprite;
    }

    //private void OnMouseExit()
    //{
    //    gameObject.GetComponent<SpriteRenderer>().sprite = previous;
    //}

    void OnClick()
    {
        imagen.sprite = onClickSprite;
    }
}
