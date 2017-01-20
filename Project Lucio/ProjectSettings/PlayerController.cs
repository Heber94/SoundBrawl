using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	public GameObject wavePrefab;
	public Transform waveSpawn;

	void Update()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
	}


	void Fire()
	{
		// Create the wave from the wave Prefab
		var wave = (GameObject)Instantiate(
			wavePrefab,
			waveSpawn.position,
			waveSpawn.rotation);

		// Add velocity to the wave
		wave.GetComponent<Rigidbody>().velocity = wave.transform.forward * 6;
		// Destroy the wave after 2 seconds
		Destroy(wave, 4.0f);
	}

	public override void OnStartLocalPlayer ()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}