using UnityEngine;
using System.Collections;

[System.Serializable]
public class PointAreas
{
    public Transform[] startpoints;
    public Transform[] endpoints;
}

public class EnemySpawner : MonoBehaviour
{

    public PointAreas[] pointAreas;
    public int currentArea = 0;
    public GameObject enemyPrefab;
    public float flyHeight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
            Debug.Log("asd");
        }
    }

    void SpawnEnemy()
    {
        int random = Random.Range(0, pointAreas[currentArea].startpoints.Length);
        int random2 = Random.Range(0, pointAreas[currentArea].endpoints.Length);

        GameObject enemy = (GameObject)Instantiate(enemyPrefab, pointAreas[currentArea].startpoints[random].position, Quaternion.identity);

        enemy.GetComponent<EnemyController>().Activate(pointAreas[currentArea].startpoints[random].position, pointAreas[currentArea].endpoints[random2].position, flyHeight);
    }
}
