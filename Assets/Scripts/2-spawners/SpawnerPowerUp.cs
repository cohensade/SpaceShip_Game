using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject powerUpPrefab;

    [SerializeField]
    float spawnInterval = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", 2f, spawnInterval);
    }

    private void SpawnPowerUp()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
    }
}
