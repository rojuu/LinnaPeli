using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour
{

    public GameObject blood;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            GameObject.FindWithTag("GameController").GetComponent<GameController>().score++;
            GameObject go = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(go, 4f);
        }
    }
}
