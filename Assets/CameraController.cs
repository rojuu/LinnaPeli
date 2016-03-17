using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform[] camerapoints;
    public float moveSpeed;

    Vector3 startposition;
    Quaternion startrotation;
    int targetpointIndex = 0;
    float moveTimer = 0f;
    bool isMoving = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActivateMovement(0);
        }

        CameraMovement();
    }

    void CameraMovement()
    {
        if (isMoving)
        {
            moveTimer += Time.deltaTime * moveSpeed;

            float t = moveTimer;

            if (moveTimer >= 1f)
            {
                isMoving = false;
                moveTimer = 0f;
            }

            t = t * t * t * (t * (6f * t - 15f) + 10f);

            transform.position = Vector3.Lerp(startposition, camerapoints[targetpointIndex].position, t);
            transform.rotation = Quaternion.Slerp(startrotation, camerapoints[targetpointIndex].localRotation, t);
        }
    }

    public void ActivateMovement(int endpointIndex)
    {
        startposition = transform.position;
        startrotation = transform.localRotation;
        targetpointIndex = endpointIndex;
        isMoving = true;
    }
}
