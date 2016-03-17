using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public GameObject turret;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0)  * Time.deltaTime  * 100);
        turret.transform.Rotate(new Vector3(Input.GetAxis("MouseY"), 0, 0) * Time.deltaTime * 100);
	}
}
