using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(col.gameObject);
            GameObject.FindWithTag("GameController").GetComponent<GameController>().score++;
        }
    }
}
