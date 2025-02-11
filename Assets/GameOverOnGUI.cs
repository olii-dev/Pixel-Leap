using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnGUI : MonoBehaviour
{
    public bool gameOver = false;
    public int fontSize = 40;
    [SerializeField] private Font Font;

void OnGUI()
{
    if (gameOver)
    {
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        // Create the style for the "Game Over" text
        GUIStyle titleStyle = new GUIStyle
        {
            alignment = TextAnchor.MiddleCenter,
            fontSize = fontSize,
            fontStyle = FontStyle.Bold,
            font = Font,
            normal = { textColor = Color.white }
        };

        // Draw "Game Over" text
        Rect titleRect = new Rect(screenWidth / 2 - 150, screenHeight / 2 - 100, 300, 200);
        GUI.Label(titleRect, "Game Over", titleStyle);

        // Display the high score at the right side of the screen
        GUIStyle highScoreStyle = new GUIStyle
        {
            alignment = TextAnchor.MiddleRight,
            fontSize = 30,
            fontStyle = FontStyle.Bold,
            font = Font,
            normal = { textColor = Color.yellow }  // You can change the color here
        };

        // Define the position for the high score (right side of the screen)
        Rect highScoreRect = new Rect(screenWidth - 250, 50, 200, 50); // Adjusted position
        GUI.Label(highScoreRect, "High: " + PlayerPrefs.GetInt("HighScore", 0), highScoreStyle);

        // Draw restart button
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 18,
            fontStyle = FontStyle.Bold,
            normal = { textColor = Color.white, background = CreateColorTexture(new Color(0.1f, 0.2f, 0.8f)) }, // Light blue for normal
            hover = { textColor = Color.white, background = CreateColorTexture(new Color(0.2f, 0.4f, 1f)) }, // Light blue hover
            active = { textColor = Color.white, background = CreateColorTexture(new Color(0.1f, 0.3f, 0.9f)) }, // Slightly darker blue on click
            alignment = TextAnchor.MiddleCenter,
            font = Font
        };

        buttonStyle.border = new RectOffset(10, 10, 10, 10);
        buttonStyle.padding = new RectOffset(10, 10, 10, 10);

        Rect buttonRect = new Rect(screenWidth / 2 - 75, screenHeight / 2 + 50, 150, 50);
        if (GUI.Button(buttonRect, "Restart", buttonStyle))
        {
            RestartGame();
        }
    }
}

    public void ShowGameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        // Find ScoreManager and reset score if found
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetScore(); // Reset score on restart
        }
        else
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Helper method to create a single-color texture for the button background
    private Texture2D CreateColorTexture(Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        return texture;
    }
}