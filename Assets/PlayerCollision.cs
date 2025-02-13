using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameOverOnGUI gameOverManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over - Player hit an obstacle!");
            gameOverManager.ShowGameOver();
        }
    }
}