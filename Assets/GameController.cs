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
    public GameObject gameOver;
    bool isGameOver = false;
    public GameObject castle;

    Rigidbody[] castlePieces;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cameraController = Camera.main.GetComponent<CameraController>();
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    void Start()
    {
        currentHealth = maxHeath;
        castlePieces = castle.GetComponentsInChildren<Rigidbody>();
    }

    void Update()
    {
        if (Input.anyKeyDown && isGameOver)
        {
            Retry();
        }

        if (currentHealth <= 0)
        {
            gameOver.SetActive(true);
            isGameOver = true;
            foreach(Rigidbody rig in castlePieces)
            {
                rig.isKinematic = false;
                rig.useGravity = true;
                rig.AddForce(new Vector3(Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f)));
            }
        }
        else
        {
            gameOver.SetActive(false);
        }


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

    public void Retry()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
