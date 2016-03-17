using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public GameObject barrel;
    public GameObject cannonBall;
    public GameObject shootLocation;

    public float delay = 0.2f;
    float time;

    public int id = 0;

    GameController gameController;
    
	// Use this for initialization
	void Start () {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        time = delay;
	}
	
	// Update is called once per frame
	void Update () {
        if (id == gameController.currentCannon)
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 100);
            barrel.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse Y"), 0) * Time.deltaTime * 100);

            time += Time.deltaTime;

            if (Input.GetKey(KeyCode.Mouse0) && time > delay)
            {
                time = 0f;
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                GameObject ammo = (GameObject)Instantiate(cannonBall, shootLocation.transform.position, shootLocation.transform.rotation);
                ammo.GetComponent<Rigidbody>().AddForce(shootLocation.transform.forward * 5000);
            } 
        }
	}
}
