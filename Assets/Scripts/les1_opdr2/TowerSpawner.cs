using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPos = GetRandomPosition();
            SpawnTower(spawnPos);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-5f, 5f);
        float z = Random.Range(-5f, 5f);
        return new Vector3(x, 0f, z);
    }

    private void SpawnTower(Vector3 position)
    {
        Instantiate(towerPrefab, position, Quaternion.identity);
    }
}
