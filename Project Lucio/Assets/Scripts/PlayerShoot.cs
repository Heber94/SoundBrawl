using UnityEngine;

public class PlayerShoot : MonoBehaviour
{


    public string prefix;
    public GameObject wavePrefab;
    public Transform waveSpawn;
    float nextSpawnTime = 0f;
    public float delay = 1f;
    int nShots = 0;
    public Animator anim;

    float downMoment, upMoment, pressTime = 0;

    bool ready = false;

    void Start()
    {
        nextSpawnTime = Time.time + delay;
    }
    void Update()
    {

       

        //if (Input.GetButtonDown(prefix +"Fire1")) {
        if (Input.GetButtonDown(prefix + "Fire1"))
        {
            Debug.Log("Entra");
            anim.SetBool("AttackCharge", true);
            downMoment = Time.time;
        }
        //if (Input.GetButtonDown(prefix + "Fire1")) {
        if (Input.GetButtonUp(prefix + "Fire1"))
        {
            anim.SetBool("AttackCharge", false);
            upMoment = Time.time;
            pressTime = upMoment - downMoment;
            if (pressTime > 0.1)
            {
                nShots = 1;
            }
            if (pressTime > 0.4)
            {
                nShots = 2;
            }
            if (pressTime > 0.6)
            {
                nShots = 3;
            }
            if (pressTime > 0.8)
            {
                nShots = 4;
            }
            if (pressTime > 1)
            {
                nShots = 5;
            }
        }

        if (nShots > 0 && Time.time > nextSpawnTime)
        {
            nShots -= 1;
            nextSpawnTime = delay + Time.time;

            Debug.Log(nextSpawnTime + " " + Time.time);

            GameObject wave = (GameObject)Instantiate(wavePrefab, waveSpawn.position, waveSpawn.rotation);
            wave.gameObject.tag = "Wave";
            // Add velocity to the wave
            wave.GetComponent<Rigidbody>().velocity = wave.transform.right * 6;

            // Destroy the wave after 2 seconds
            Destroy(wave, 1.0f);
        }
    }


    
}