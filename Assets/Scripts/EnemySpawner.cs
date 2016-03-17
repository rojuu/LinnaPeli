using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PointAreas
{
    public Transform[] startpoints;
    public Transform[] endpoints;
}

public class EnemySpawner : MonoBehaviour
{
    public PointAreas[] pointAreas;
    public WaveIndicator[] indicators;
    public GameObject enemyPrefab;
    public float flyHeight;
    public float spawnDelay;
    public int currentWaveEnemies;
    public int increasedEnemiesPerWave;
    public int[] cannonActivationWaves;
    public float waveDelay;
    public enum WaveState { Start, Playing, End }
    public WaveState waveState = WaveState.Start;

    GameController gameController;
    public int[] enemyPools;
    public int[] activeEnemies;
    float spawnTimer = 0f;

    void Awake()
    {
        gameController = GetComponent<GameController>();
        enemyPools = new int[pointAreas.Length];
        activeEnemies = new int[pointAreas.Length];

    }

    void Start()
    {
        InitializeWave();
    }

    void Update()
    {
        switch (waveState)
        {
            case WaveState.Start:
                
                break;

            case WaveState.Playing:
                WaveSpawner();
                break;

            case WaveState.End:

                break;

            default:
                break;
        }

        for (int i = 0; i < enemyPools.Length; i++)
        {
            if (activeEnemies[i] > 0)
            {
                indicators[i].indicate = true;
            }
            else
            {
                indicators[i].indicate = false;
            }
        }
    }

    void InitializeWave()
    {
        waveState = WaveState.Playing;

        currentWaveEnemies = increasedEnemiesPerWave * gameController.wave;

        int undistributedEnemies = currentWaveEnemies;

        int cannonCount = 1;

        for (int i = 0; i < cannonActivationWaves.Length; i++)
        {
            if (gameController.wave >= cannonActivationWaves[i])
            {
                cannonCount++;
            }
            else
            {
                break;
            }
        }

        for (int i = 0; i < enemyPools.Length; i++)
        {
            enemyPools[i] = 0;
        }

        for (int i = 0; i < cannonCount; i++)
        {
            if (i == cannonCount - 1)
            {
                enemyPools[i] = undistributedEnemies;
            }
            else
            {
                int randomOffset = Random.Range(-currentWaveEnemies / 10, currentWaveEnemies / 10);
                enemyPools[i] = currentWaveEnemies / cannonCount + randomOffset;
                undistributedEnemies -= currentWaveEnemies / cannonCount + randomOffset;
            }
        }
    }

    void WaveSpawner()
    {
        bool noEnemies = true;
        List<int> availablePools = new List<int>();

        for (int i = 0; i < enemyPools.Length; i++)
        {
            if (enemyPools[i] > 0)
            {
                noEnemies = false;
                availablePools.Add(i);
            }
        }

        if (noEnemies)
        {
            EndWave();
        }
        else
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnDelay)
            {
                int random = Random.Range(0, availablePools.Count);
                int random2 = availablePools[random];

                spawnTimer = 0f;

                enemyPools[random2]--;
                currentWaveEnemies--;

                SpawnEnemy(random2);
            }
        }
    }

    void EndWave()
    {
        waveState = WaveState.Start;
        StartCoroutine(NewWaveTimer());
    }

    IEnumerator NewWaveTimer()
    {
        yield return new WaitForSeconds(waveDelay);
        gameController.wave++;
        InitializeWave();
    }

    void SpawnEnemy(int spawnarea)
    {
        activeEnemies[spawnarea]++;

        int random = Random.Range(0, pointAreas[spawnarea].startpoints.Length);
        int random2 = Random.Range(0, pointAreas[spawnarea].endpoints.Length);

        GameObject enemy = (GameObject)Instantiate(enemyPrefab, pointAreas[spawnarea].startpoints[random].position, Quaternion.identity);

        enemy.GetComponent<EnemyController>().Activate(pointAreas[spawnarea].startpoints[random].position, pointAreas[spawnarea].endpoints[random2].position, flyHeight, spawnarea);
    }
}
