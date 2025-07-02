using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI;
    public TMP_Text highScoreText;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        UpdateHighScoreDisplay();
    }

    void Update()
    {
        // Using the new Input System for Escape key
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // Assuming main menu is scene index 0
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveGame()
    {
        // Get current score from ScoreController
        ScoreController scoreController = FindObjectOfType<ScoreController>();
        if (scoreController != null)
        {
            // Try to find player object to get position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 playerPosition = Vector3.zero;
            if (player != null)
            {
                playerPosition = player.transform.position;
            }
            
            GameStateManager.SaveGame(scoreController.Score, playerPosition);
            Debug.Log("Game saved successfully!");
        }
    }

    public void SaveAndQuit()
    {
        SaveGame();
        ReturnToMainMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    // Method to update high score display
    public void UpdateHighScoreDisplay()
    {
        if (highScoreText != null)
        {
            int highScore = GameStateManager.LoadHighScore();
            highScoreText.text = $"High Score: {highScore}";
        }
    }

    // Method to save current score as high score (can be called by a button)
    public void SaveHighScore()
    {
        // Get current score from ScoreController if available
        ScoreController scoreController = FindObjectOfType<ScoreController>();
        if (scoreController != null)
        {
            GameStateManager.SaveHighScore(scoreController.Score);
            UpdateHighScoreDisplay();
        }
    }

    // Method to reset high score (can be called by a button)
    public void ResetHighScore()
    {
        GameStateManager.DeleteSavedGame();
        UpdateHighScoreDisplay();
    }
}
