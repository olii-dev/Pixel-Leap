using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    public float obstacleSpeed = 5f;
    public float spawnY = -3f;
    public float spawnXMin = 10f;
    public float spawnXMax = 15f;

    void Start()
    {
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(spawnXMin, spawnXMax);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        obstacle.AddComponent<ObstacleMovement>().speed = obstacleSpeed;

        float randomDelay = Random.Range(minSpawnTime, maxSpawnTime);

        Invoke("SpawnObstacle", randomDelay);
    }
}