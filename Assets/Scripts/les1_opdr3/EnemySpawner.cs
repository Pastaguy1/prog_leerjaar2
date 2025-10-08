using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<GameObject> enemies = new List<GameObject>();

    public float autoSpawnInterval = 1f; 
    public int autoSpawnAmount = 3;

    void Start()
    {
        StartCoroutine(AutoSpawnEnemies());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnEnemies(100);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveAllEnemies();
        }
    }

    private IEnumerator AutoSpawnEnemies()
    {
        while (true)
        {
            SpawnEnemies(autoSpawnAmount);
            yield return new WaitForSeconds(autoSpawnInterval);
        }
    }
    private void SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            // Random spawn rondom de spawner
            Vector3 spawnPos = transform.position + new Vector3(
                Random.Range(-2f, 2f),
                0,
                Random.Range(-2f, 2f)
            );

            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemies.Add(enemy);
        }
    }


    private void RemoveAllEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
                Destroy(enemy);
        }

        enemies.Clear();
    }
}
