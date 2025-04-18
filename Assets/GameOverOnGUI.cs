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

            GUIStyle titleStyle = new GUIStyle
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = fontSize,
                fontStyle = FontStyle.Bold,
                font = Font,
                normal = { textColor = Color.white }
            };

            // "Game Over" text
            Rect titleRect = new Rect(screenWidth / 2 - 150, screenHeight / 2 - 100, 300, 200);
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

            Rect buttonRect = new Rect(screenWidth / 2 - 75, screenHeight / 2 + 50, 150, 50);
            if (GUI.Button(buttonRect, "Play again", buttonStyle))
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

    private Texture2D CreateColorTexture(Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        return texture;
    }
}