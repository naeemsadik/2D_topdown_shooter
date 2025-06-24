using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    }
    
}
