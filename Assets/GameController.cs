using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public int currentArea = 0;
    public int wave = 1;
    public int currentCannon = 0;
    public int currentHealth;
    public int maxHeath;
    CameraController cameraController;

    void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    void Start()
    {
        currentHealth = maxHeath;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !cameraController.isMoving)
        {
            currentCannon = 0;
            cameraController.ActivateMovement(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !cameraController.isMoving)
        {
            currentCannon = 1;
            cameraController.ActivateMovement(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && !cameraController.isMoving)
        {
            currentCannon = 2;
            cameraController.ActivateMovement(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && !cameraController.isMoving)
        {
            currentCannon = 3;
            cameraController.ActivateMovement(3);
        }
    }
}
