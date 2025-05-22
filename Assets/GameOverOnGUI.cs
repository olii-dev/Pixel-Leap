using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnGUI : MonoBehaviour
{
    public bool gameOver = false;
    public int fontSize = 40;
    [SerializeField] private Font Font;
    [SerializeField] private AudioClip gameOverAudio; // Add this for the game over sound
    private AudioSource audioSource;

    private void Start()
    {
        // Initialize the AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
    }

void OnGUI()
{
    if (gameOver)
    {
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        GUIStyle titleStyle = new GUIStyle
        {
            alignment = TextAnchor.MiddleCenter,
            fontSize = fontSize,
            fontStyle = FontStyle.Bold,
            font = Font,
            normal = { textColor = Color.white }
        };

        // "Game Over" text
        Rect titleRect = new Rect(screenWidth / 2 - 150, screenHeight / 2 - 150, 300, 200); // Moved higher by reducing y value
        titleStyle.normal.textColor = Color.black; // Change text color to black
        GUI.Label(titleRect, "Game Over!", titleStyle);

        // Restart button
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 18,
            fontStyle = FontStyle.Bold,
            normal = { textColor = Color.white, background = CreateColorTexture(new Color(0.1f, 0.2f, 0.8f)) },
            hover = { textColor = Color.white, background = CreateColorTexture(new Color(0.2f, 0.4f, 1f)) },
            active = { textColor = Color.white, background = CreateColorTexture(new Color(0.1f, 0.3f, 0.9f)) },
            alignment = TextAnchor.MiddleCenter,
            font = Font
        };

        buttonStyle.border = new RectOffset(10, 10, 10, 10);
        buttonStyle.padding = new RectOffset(10, 10, 10, 10);

        // Play Again button
        Rect playAgainButtonRect = new Rect(screenWidth / 2 - 75, screenHeight / 2 + 20, 150, 50); // Moved higher by reducing y value
        if (GUI.Button(playAgainButtonRect, "Play again", buttonStyle))
        {
            RestartGame();
        }

        // Return to Main Menu button
        GUIStyle smallButtonStyle = new GUIStyle(buttonStyle)
        {
            fontSize = 11 // Smaller font size for "Main Menu"
        };

        Rect mainMenuButtonRect = new Rect(screenWidth / 2 - 50, screenHeight / 2 + 90, 100, 40); // Moved higher by reducing y value
        if (GUI.Button(mainMenuButtonRect, "Main Menu", smallButtonStyle))
        {
            ReturnToMainMenu();
        }
    }
}

    public void ShowGameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;

        // Stop all other audio sources in the scene
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allAudioSources)
        {
            if (source != audioSource)
            {
                source.Stop();
            }
        }

        if (gameOverAudio != null && audioSource != null)
        {
            audioSource.PlayOneShot(gameOverAudio, 0.6f);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }
        else
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private Texture2D CreateColorTexture(Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        return texture;
    }
}