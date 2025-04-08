using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the next scene based on the current scene's build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
