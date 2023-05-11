using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enenmyPrefab;
    public GameObject powerupPrefab;

    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnLocation(), powerupPrefab.transform.rotation);
        
    }

    private Vector3 GenerateSpawnLocation()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++) 
        {
            Instantiate(enenmyPrefab, GenerateSpawnLocation(), enenmyPrefab.transform.rotation);
        }
    }

    void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnLocation(), powerupPrefab.transform.rotation);
        }
    }
}
