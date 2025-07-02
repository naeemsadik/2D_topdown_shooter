using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    // Event triggered whenever the score changes
    public UnityEvent OnScoreChanged;

    // Public property to get the current score (read-only from outside)
    public int Score { get; private set; }

    // Adds the given amount to the score and triggers the score changed event
    public void AddScore(int amount)
    {
        Score += amount;

        // Notify any listeners that the score has changed (e.g., UI)
        OnScoreChanged.Invoke();

        // Save the high score
        GameStateManager.SaveHighScore(Score);
        
        // Check if score reaches the level-up threshold
        CheckLevelProgression();
    }
    
    // Sets the score directly (used for loading saved games)
    public void SetScore(int newScore)
    {
        Score = newScore;
        OnScoreChanged.Invoke();
        GameStateManager.SaveHighScore(Score);
    }
    
    // Checks if the player should progress to the next level
    private void CheckLevelProgression()
    {
        if (Score >= 350)
        {
            SceneManager.LoadScene("Level2"); // Adjust scene name as needed
        }
    }
    
}
