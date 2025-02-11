using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    private int highScore = 0;
    public GUIStyle scoreStyle;
    public GUIStyle highScoreStyle;
    public Font customFont;

    private void Start()
    {
        // Load high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Start increasing score every 0.3 seconds
        InvokeRepeating("IncreaseScore", 1f, 0.3f);
    }

    void IncreaseScore()
    {
        score += 1;

        // Update high score if necessary
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    void OnGUI()
    {
        // Set up styles
        scoreStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 40,
            font = customFont,
            normal = { textColor = Color.white }
        };

        highScoreStyle = new GUIStyle(scoreStyle)
        {
            fontSize = 30
        };

        // Draw score (left side)
        GUI.Label(new Rect(20, 20, 300, 50), "Score: " + score, scoreStyle);

        // Draw high score (right side)
        GUI.Label(new Rect(Screen.width - 220, 20, 200, 50), "High Score: " + highScore, highScoreStyle);
    }

    // Reset score
    public void ResetScore()
    {
        score = 0;
    }
}