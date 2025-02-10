using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public GUIStyle scoreStyle;
    [SerializeField] private Font font; // Allows font selection in Inspector

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        InvokeRepeating("IncreaseScore", 1f, 0.3f); // Increase score every 0.3 seconds
    }

    void IncreaseScore()
    {
        score += 1;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    void OnGUI()
    {
        scoreStyle = new GUIStyle(GUI.skin.label);
        scoreStyle.fontSize = 40;
        scoreStyle.normal.textColor = Color.white;

        if (font != null) // Apply font if assigned
        {
            scoreStyle.font = font;
        }

        GUI.Label(new Rect(20, 20, 200, 50), "Score: " + score, scoreStyle);
        GUI.Label(new Rect(20, 70, 200, 50), "High Score: " + highScore, scoreStyle);
    }
}