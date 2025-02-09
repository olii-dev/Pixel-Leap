using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameOverOnGUI gameOverManager;  // Reference to the GameOverOnGUI script

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with an obstacle
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over - Player hit an obstacle!");
            gameOverManager.ShowGameOver();  // Show the Game Over screen
        }
    }
}