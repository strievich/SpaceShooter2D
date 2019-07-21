using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform spawnPoint;
    public float spawnPointWidth;
    public float spawnWait;
    public float startWait;
    private bool stopSpawn = false;
    
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Vector3 spawnPosition = new Vector3(spawnPoint.position.x, Random.Range(-spawnPointWidth / 2.0f, spawnPointWidth / 2.0f), spawnPoint.position.z);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);

            if (stopSpawn)
            {
                break;
            }
        }
    }

    public void GameOver()
    {
        stopSpawn = true;
    }

}
