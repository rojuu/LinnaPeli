using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public int currentArea = 0;
    public int wave = 1;
    public int currentCannon = 0;

    void Awake()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
