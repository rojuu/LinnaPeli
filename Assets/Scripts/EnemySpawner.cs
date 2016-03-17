using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    Random rnd = new Random();

    public GameObject enemyPrefab;
    public Vector3 startpoint;
    public Vector3 endpoint;
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
        GameObject enemy = (GameObject)Instantiate(enemyPrefab, startpoint, Quaternion.identity);

        enemy.GetComponent<EnemyController>().Activate(startpoint, endpoint, flyHeight);
    }
}
