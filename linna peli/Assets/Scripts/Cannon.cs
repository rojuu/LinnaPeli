﻿using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0)  * Time.deltaTime  * 10);
	}
}
