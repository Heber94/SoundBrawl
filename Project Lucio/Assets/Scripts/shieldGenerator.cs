using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shieldGenerator : MonoBehaviour {
    AudioSource audiocarga;
    public AudioClip carga;
    public AudioClip explota;
    
	public GameObject shield; 
	[HideInInspector] public Collider[] colliders;
	public ParticleSystem explosion;
    public string prefix;
    public float shieldTime = 2f;
    [HideInInspector] public static float sT;
    public float timeTillUseAgain = 5f;
    private float tTUA;

    public Slider shieldSlider;
    public Color MaxShieldColor = Color.green;
    public Color MinShieldColor = Color.red;

    void Start () {
        audiocarga = GetComponent<AudioSource>();

        shield.layer = 8;
        shield.SetActive(false);
        sT = shieldTime;
        tTUA = 0;
    }
	
	void Update () {
        
		float targetScale = 5f;
		float growSpeed = 2.5f;
		Vector3 scale = transform.localScale;

        //If we're pressing the shield button, it increase each frame till reach maximun size
        if (tTUA <= 0)
        {
            if (Input.GetButtonDown(prefix + "Shield"))
            {
                shield.SetActive(true);

                shield.transform.position = transform.position;
                shield.transform.localScale = transform.localScale / 4;
            }else if (Input.GetButton(prefix + "Shield"))
            {
                audiocarga.clip = carga;
                audiocarga.loop = false;
                audiocarga.Play();

                shield.transform.localScale = Vector3.Lerp(shield.transform.localScale,
                             new Vector3(transform.localScale.x + targetScale,
                             transform.localScale.y + targetScale,
                             transform.localScale.z + targetScale), Time.deltaTime * growSpeed);
                scale = shield.transform.localScale;
                sT -= Time.deltaTime;
                shieldSlider.value = ((shieldTime - sT) * 100) / shieldTime;
            } else if (Input.GetButtonUp(prefix + "Shield"))   
                //When we release the shield button, it dissapear, play the sound and is restored to its default values
            {
                audiocarga.clip = explota;
                audiocarga.Stop();

                explosion.transform.position = transform.position;
                explosion.Play();

                shield.SetActive(false);
            }
            else if(sT < shieldTime)
            {
                sT += Time.deltaTime;
                shieldSlider.value = ((shieldTime - sT) * 100) / shieldTime;
            }

            if (sT <= 0)
            {
                audiocarga.clip = explota;
                audiocarga.Stop();

                explosion.transform.position = transform.position;
                explosion.Play();

                //Debug.Log("shieldExplote!");

                tTUA = timeTillUseAgain;
                sT = shieldTime;

                shield.SetActive(false);
            }
            //shieldSlider.colors = Color.Lerp(MinShieldColor, MaxShieldColor, (float)sT / shieldTime);
            shieldSlider.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(MinShieldColor, MaxShieldColor, (float)sT / shieldTime);
        }
        else
        {
            tTUA -= Time.deltaTime;
            shieldSlider.value = (tTUA / timeTillUseAgain) * 100;
            shieldSlider.GetComponentInChildren<UnityEngine.UI.Image>().color = MinShieldColor;
        }
        
    }

}



