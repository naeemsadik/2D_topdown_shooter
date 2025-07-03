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
        return PlayerPrefs.HasKey("CurrentScore") && PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY");
    }

    /// <summary>
    /// Saves the current game state.
    /// </summary>
    public static void SaveGame(int score, Vector3 position)
    {
        PlayerPrefs.SetInt("CurrentScore", score);
        PlayerPrefs.SetFloat("PlayerPosX", position.x);
        PlayerPrefs.SetFloat("PlayerPosY", position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", position.z);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Loads the saved game state.
    /// </summary>
    public static (int, Vector3) LoadGame()
    {
        int score = PlayerPrefs.GetInt("CurrentScore", 0);
        float x = PlayerPrefs.GetFloat("PlayerPosX", 0f);
        float y = PlayerPrefs.GetFloat("PlayerPosY", 0f);
        float z = PlayerPrefs.GetFloat("PlayerPosZ", 0f);
        return (score, new Vector3(x, y, z));
    }

    /// <summary>
    /// Clears the saved high score.
    /// </summary>
    public static void DeleteSavedGame()
    {
        PlayerPrefs.DeleteKey(HighScoreKey);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Clears the saved game data (used when starting new game).
    /// </summary>
    public static void ClearSavedGame()
    {
        PlayerPrefs.DeleteKey("CurrentScore");
        PlayerPrefs.DeleteKey("PlayerPosX");
        PlayerPrefs.DeleteKey("PlayerPosY");
        PlayerPrefs.DeleteKey("PlayerPosZ");
        PlayerPrefs.Save();
    }
}
