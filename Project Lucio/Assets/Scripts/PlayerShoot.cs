using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject wavePrefab;
	public Transform waveSpawn;
	public float nextSpawnTime = 0f;
	public float delay = 0.1f;
	public int nShots = 0;


	public float downMoment, upMoment, pressTime = 0;
	public float chargeTime = 0.5f;
	public bool ready = false;

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			downMoment = Time.time;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			upMoment = Time.time;
			pressTime = upMoment - downMoment;
			if (pressTime > 0.2) {
				nShots = 1;
			}if (pressTime > 0.4) {
				nShots = 2;
			}if (pressTime > 0.6) {
				nShots = 3;
			}if (pressTime > 0.8) {
				nShots = 4;
			}if (pressTime > 1) {
				nShots = 5;
			}
		}

		if (nShots > 0 && Time.time > nextSpawnTime) {
			nShots -= 1;
			nextSpawnTime = delay + Time.time;
			var wave = (GameObject)Instantiate(
				wavePrefab,
				waveSpawn.position,
				waveSpawn.rotation);

			// Add velocity to the wave
			wave.GetComponent<Rigidbody>().velocity = - wave.transform.right * 6;

			// Destroy the wave after 2 seconds
			Destroy(wave, 1.0f);
		}
	}
}