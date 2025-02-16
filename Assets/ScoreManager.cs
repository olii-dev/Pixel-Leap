using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    private int highScore = 0;
    public GUIStyle scoreStyle;
    public GUIStyle highScoreStyle;
    public Font customFont;

    public float baseObstacleSpeed = 5f;
    public float speedIncrease = 0.5f;
    private int nextSpeedIncrease = 200;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        InvokeRepeating("IncreaseScore", 1f, 0.3f);
    }

    void IncreaseScore()
    {
        score += 1;

        if (score >= nextSpeedIncrease)
        {
            baseObstacleSpeed += speedIncrease;
            nextSpeedIncrease += 200;
        }

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    void OnGUI()
    {
        scoreStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 40,
            font = customFont,
            normal = { textColor = Color.white }
        };

        highScoreStyle = new GUIStyle(scoreStyle)
        {
            fontSize = 30,
            alignment = TextAnchor.UpperRight
        };

        GUI.Label(new Rect(20, 20, 300, 50), "Score: " + score, scoreStyle);
        GUI.Label(new Rect(Screen.width - 250, 20, 230, 50), "High: " + highScore, highScoreStyle);
    }

    public void ResetScore()
    {
        score = 0;
        baseObstacleSpeed = 5f;
        nextSpeedIncrease = 200;
    }
}