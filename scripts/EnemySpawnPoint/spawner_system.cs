using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_system : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    public Transform[] spawnLocations; // Array of spawn points

    public GameObject[] bossPrefabs;

    private int waveNumber = 1; // Current wave number
    private int enemiesToSpawn; // Number of enemies to spawn this wave
    private List<GameObject> activeEnemies = new List<GameObject>(); // Track active enemies
    public WaveNumber WaveNumber;

    void Start()
    {
        if (spawnLocations.Length == 0)
        {
            Debug.LogError("No spawn locations assigned!");
            return;
        }

        if (enemyPrefabs.Length == 0)
        {
            Debug.LogError("No enemy prefabs assigned!");
            return;
        }

        StartCoroutine(SpawnWave());
    }

    void Update()
    {

        if (activeEnemies.Count == 0 && enemiesToSpawn == 0)
        {
            waveNumber++;
            StartCoroutine(SpawnWave());
        }


        activeEnemies.RemoveAll(enemy => enemy == null);
    }

    private IEnumerator SpawnWave()
    {
        enemiesToSpawn = waveNumber;
        WaveNumber.IncrementWaveNum();
        for (int i = 0; i < enemiesToSpawn; i++)
        {

            Transform spawnPoint = spawnLocations[Random.Range(0, spawnLocations.Length)];

            GameObject enemyArr= enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            GameObject enemy = Instantiate(enemyArr, spawnPoint.position, transform.rotation);

            activeEnemies.Add(enemy);

            yield return new WaitForSeconds(0.5f); 
        }
        /*
        if(waveNumber % 5 == 1)
        {
            Transform spawnPoint = spawnLocations[Random.Range(0, spawnLocations.Length)];
            // Randomly choose an enemy prefab
            GameObject bossArr = bossPrefabs[Random.Range(0, bossPrefabs.Length)];
            // Spawn the enemy
            GameObject enemy = Instantiate(bossArr, spawnPoint.position, transform.rotation);
        }
        */
        enemiesToSpawn = 0; 
    }
}
