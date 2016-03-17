using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    Vector3[] path = new Vector3[3];
    EnemySpawner spawnerController;
    GameController gameController;
    int areaIndex;

    public float speed;

    void Awake()
    {
        spawnerController = GameObject.FindWithTag("GameController").GetComponent<EnemySpawner>();
    }

    void Update()
    {
        
    }

    public void Activate(Vector3 startpoint, Vector3 endpoint, float flyHeight, int spawnArea)
    {
        areaIndex = spawnArea;

        path[0] = startpoint;
        path[1] = (startpoint + endpoint) / 2 + new Vector3(0f,flyHeight,0f);
        path[2] = endpoint;

        iTween.MoveTo(gameObject, iTween.Hash("position", endpoint, "path", path, "orienttopath", false, "looptype", iTween.LoopType.none, "easetype", iTween.EaseType.linear, "oncomplete", "PathEnd", "speed", speed));
     }

    void PathEnd()
    {
        spawnerController.activeEnemies[areaIndex]--;
        Destroy(gameObject);
    }
}
