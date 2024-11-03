using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;          // Assign your asteroid prefab here
    public int spawnCount = 20;                // Number of asteroids to spawn at once
    public float spawnRadius = 50f;            // Radius within which to spawn asteroids
    public float spawnInterval = 5f;           // Time interval for spawning asteroids

    void Start()
    {
        // Start spawning asteroids repeatedly
        InvokeRepeating("SpawnAsteroids", 0f, spawnInterval);
    }

    private void SpawnAsteroids()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // Calculate a random position in a sphere of spawnRadius around the spawner
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            // Instantiate a new asteroid at the calculated position with random rotation
            Instantiate(asteroidPrefab, randomPosition, Random.rotation);
        }
    }
}
