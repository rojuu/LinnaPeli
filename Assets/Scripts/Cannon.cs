using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public GameObject barrel;
    public GameObject cannonBall;
    public GameObject shootLocation;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0)  * Time.deltaTime  * 100);
        barrel.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * 100);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject ammo = (GameObject)Instantiate(cannonBall, shootLocation.transform.position, shootLocation.transform.rotation);
            ammo.GetComponent<Rigidbody>().AddForce(shootLocation.transform.forward * 1000);
        }
	}
}
