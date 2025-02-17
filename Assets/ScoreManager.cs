using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    private int highScore = 0;
    public GUIStyle scoreStyle;
    public GUIStyle highScoreStyle;
    public Font customFont;

    // Obstacle speed settings
    public float baseObstacleSpeed = 5f;
    public float speedIncrease = 0.5f;
    private int nextSpeedIncrease = 100;

    private void Start()
    {
        // Load high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Increase score every 0.3 seconds
        InvokeRepeating("IncreaseScore", 1f, 0.3f);
    }

    void IncreaseScore()
    {
        score += 1;

        // Increase obstacle speed every time the score reaches the next threshold
        if (score >= nextSpeedIncrease)
        {
            baseObstacleSpeed += speedIncrease;
            nextSpeedIncrease += 100;
        }

        // Update high score if needed
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    void OnGUI()
    {
        // Set up style for current score (left side)
        scoreStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 40,
            font = customFont,
            normal = { textColor = Color.white }
        };

        // Set up style for high score (right side)
        highScoreStyle = new GUIStyle(scoreStyle)
        {
            fontSize = 30,
            alignment = TextAnchor.UpperRight
        };

        // Display current score on the left
        GUI.Label(new Rect(20, 20, 300, 50), "Score: " + score, scoreStyle);

        // Display high score on the right (always visible)
        GUI.Label(new Rect(Screen.width - 250, 20, 230, 50), "High: " + highScore, highScoreStyle);
    }

    // Call this method when restarting the game to reset score and speed settings
    public void ResetScore()
    {
        score = 0;
        baseObstacleSpeed = 5f;
        nextSpeedIncrease = 100;
    }
}