using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    public static void SaveHighScore(int score)
    {
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
            PlayerPrefs.Save();
        }
    }

    public static int LoadHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    public static bool HasSavedGame()
    {
        return PlayerPrefs.HasKey(HighScoreKey);
    }

    public static void DeleteSavedGame()
    {
        PlayerPrefs.DeleteKey(HighScoreKey);
        PlayerPrefs.Save();
    }
}