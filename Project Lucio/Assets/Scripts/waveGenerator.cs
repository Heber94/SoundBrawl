using UnityEngine;
using System.Collections;

public class waveGenerator : MonoBehaviour {


    AudioSource audiocarga;
    public AudioClip carga;
    public AudioClip explota;
    
     
	public GameObject sphere; 
	public GameObject killerSphere;
	public Collider[] colliders;
	public ParticleSystem explosion;
    public string prefix;
	// Use this for initialization


	void Start () {
        audiocarga = GetComponent<AudioSource>();
		sphere.transform.position = transform.position;
		sphere.transform.localScale = transform.localScale/4;
		sphere.tag = "Wave";
        sphere.layer = 8;

	}
	
	// Update is called once per frame
	void Update () {
		
		sphere.SetActive (true);
		float targetScale = 5f;
		//float shrinkSpeed = 3.5f;
		float growSpeed = 2.5f;
		Vector3 scale = transform.localScale;
		sphere.tag = "Wave";
		if (Input.GetButton(prefix + "Melee")) {
            audiocarga.clip = carga;
            audiocarga.loop = false;
            audiocarga.Play();

			sphere.transform.localScale = Vector3.Lerp (sphere.transform.localScale, 
			             new Vector3 (transform.localScale.x + targetScale,
			             transform.localScale.y + targetScale,
			             transform.localScale.z + targetScale), Time.deltaTime * growSpeed);
			scale = sphere.transform.localScale;
			//			sphereCollider.transform.localScale = Vector3.Lerp (sphere.transform.localScale, 
			//			                                                    new Vector3 (transform.localScale.x + targetScale,
			//			            transform.localScale.y + targetScale,
			//			            transform.localScale.z + targetScale), Time.deltaTime * growSpeed);
		} 
		if (Input.GetButtonUp(prefix + "Melee")) {
            audiocarga.clip = explota;
            audiocarga.loop = false;
            audiocarga.Play();
            
			explosion.transform.position = transform.position;
			explosion.Play();
			killerSphere.SetActive(true);
			killerSphere.transform.position = transform.position;
			killerSphere.transform.localScale = sphere.transform.localScale;
			SphereCollider kscollider = killerSphere.GetComponent<SphereCollider>();
			kscollider.transform.localScale = sphere.transform.localScale;
			colliders = Physics.OverlapSphere (killerSphere.transform.position,kscollider.radius*kscollider.transform.localScale.x);

			foreach(Collider col in colliders)
			{
                if (col.tag == "Player" && col.gameObject != gameObject)
                {
                    col.gameObject.SetActive(false);
                }
			}
			
			sphere.SetActive(false);
			killerSphere.SetActive(false);
			sphere.transform.localScale = transform.localScale/4;
			killerSphere.transform.localScale = sphere.transform.localScale;
		}

	}

}
