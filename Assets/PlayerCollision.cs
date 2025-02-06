using UnityEngine;
using UnityEngine.SceneManagement; // Needed to restart the game

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!"); // Debugging
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart game
        }
    }
}