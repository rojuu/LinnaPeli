using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveIndicator : MonoBehaviour {

    public bool indicate = false;

    public float delay = 0.3f;
    float time;

	// Use this for initialization
	void Start () {
        time = delay;
	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        if (time > delay && indicate)
        {
            time = 0f;
            if (gameObject.GetComponent<Image>().color == Color.red)
            {
                gameObject.GetComponent<Image>().color = Color.white;

            }
            else
            {
                gameObject.GetComponent<Image>().color = Color.red;
            }
        }
	    
	}
}
