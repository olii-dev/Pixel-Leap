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
        // Randomize spawn position (X) within the given range
        float randomX = Random.Range(spawnXMin, spawnXMax);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

        // Instantiate the obstacle prefab
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Determine current speed from ScoreManager (or use default of 5f)
        float currentSpeed = scoreManager != null ? scoreManager.baseObstacleSpeed : 5f;

        // Get or add ObstacleMovement component and set its speed
        ObstacleMovement om = obstacle.GetComponent<ObstacleMovement>();
        if (om == null)
        {
            om = obstacle.AddComponent<ObstacleMovement>();
        }
        om.speed = currentSpeed;

        // Adjust spawn delay based on obstacle speed
        float adjustedMinSpawnTime = Mathf.Max(0.5f, minSpawnTime / (currentSpeed / 5f));
        float adjustedMaxSpawnTime = Mathf.Max(1f, maxSpawnTime / (currentSpeed / 5f));

        // Schedule the next obstacle spawn with a random delay
        float randomDelay = Random.Range(adjustedMinSpawnTime, adjustedMaxSpawnTime);
        Invoke("SpawnObstacle", randomDelay);
    }
}