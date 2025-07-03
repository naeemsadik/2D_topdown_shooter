using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public TMP_Text highScoreText;

    private void Start()
    {
        if (highScoreText != null)
        {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = "High Score: " + highScore;
        }
    }

    public void StartGame()
    {
        // Clear any existing saved game data when starting a new game
        GameStateManager.ClearSavedGame();
        SceneManager.LoadScene("Game"); // Make sure this matches the exact name of your game scene
    }

    public void ContinueGame()
    {
        if (GameStateManager.HasSavedGame())
        {
            SceneManager.LoadScene("Game"); // Load game scene and GameLoader will handle loading saved data
        }
        else
        {
            Debug.Log("No saved game found! Starting new game instead.");
            StartGame();
        }
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }
}
