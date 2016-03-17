using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    Vector3[] path = new Vector3[3];
    EnemySpawner spawnerController;
    GameController gameController;
    int areaIndex;
    Vector3 randomRotation;

    public float speed;

    void Awake()
    {
        spawnerController = GameObject.FindWithTag("GameController").GetComponent<EnemySpawner>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        transform.Rotate(randomRotation);
    }

    public void Activate(Vector3 startpoint, Vector3 endpoint, float flyHeight, int spawnArea)
    {
        randomRotation = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));

        areaIndex = spawnArea;

        path[0] = startpoint;
        path[1] = (startpoint + endpoint) / 2 + new Vector3(0f,flyHeight,0f);
        path[2] = endpoint;

        iTween.MoveTo(gameObject, iTween.Hash("position", endpoint, "path", path, "orienttopath", false, "looptype", iTween.LoopType.none, "easetype", iTween.EaseType.linear, "oncomplete", "PathEnd", "speed", speed));
     }

    void PathEnd()
    {
        gameController.currentHealth--;
        spawnerController.activeEnemies[areaIndex]--;
        Destroy(gameObject);
    }
}
