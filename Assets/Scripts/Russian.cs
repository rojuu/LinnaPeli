using UnityEngine;
using System.Collections;

public class Russian : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        col.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
