using UnityEngine;

/// <summary>
/// Manages persistent game data like high score.
/// </summary>
public static class GameStateManager
{
    private const string HighScoreKey = "HighScore";

    /// <summary>
    /// Saves a new high score if it's higher than the current one.
    /// </summary>
    public static void SaveHighScore(int score)
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Loads the saved high score.
    /// </summary>
    public static int LoadHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    /// <summary>
    /// Returns true if a high score is saved.
    /// </summary>
    public static bool HasSavedGame()
    {
        return PlayerPrefs.HasKey(HighScoreKey);
    }

    /// <summary>
    /// Clears the saved high score.
    /// </summary>
    public static void DeleteSavedGame()
    {
        PlayerPrefs.DeleteKey(HighScoreKey);
        PlayerPrefs.Save();
    }
}
