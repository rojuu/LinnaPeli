using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    Slider heathbar;
    GameController gameController;

    void Awake()
    {
        heathbar = GetComponent<Slider>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        heathbar.value = (float)gameController.currentHealth / (float)gameController.maxHeath;
    }
}
