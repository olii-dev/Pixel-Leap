using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    public float spawnY = -3f;
    public float spawnXMin = 10f;
    public float spawnXMax = 15f;

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(spawnXMin, spawnXMax);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        float currentSpeed = scoreManager != null ? scoreManager.baseObstacleSpeed : 5f;
        obstacle.AddComponent<ObstacleMovement>().speed = currentSpeed;

        float randomDelay = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("SpawnObstacle", randomDelay);
    }
}