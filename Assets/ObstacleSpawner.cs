using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    public float obstacleSpeed = 5f;
    public float spawnY = -3f;
    public float spawnXMin = 10f;  // Min X position where obstacles can spawn
    public float spawnXMax = 15f;  // Max X position where obstacles can spawn

    void Start()
    {
        // Start the first spawn immediately
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        // Randomize the spawn position on the X-axis
        float randomX = Random.Range(spawnXMin, spawnXMax);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

        // Instantiate the obstacle at the random position
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        obstacle.AddComponent<ObstacleMovement>().speed = obstacleSpeed;

        // Randomize the next spawn time
        float randomDelay = Random.Range(minSpawnTime, maxSpawnTime);

        // Call the next spawn with a random delay
        Invoke("SpawnObstacle", randomDelay);
    }
}