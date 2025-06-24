using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreAllocator : MonoBehaviour
{
    // Score to be awarded when this enemy is killed
    [SerializeField]
    private int _killScore;

    // Reference to the ScoreController to update the player's score
    private ScoreController _scoreController;

    private void Awake()
    {
        // Find the ScoreController in the scene and store a reference to it
        _scoreController = FindObjectOfType<ScoreController>();

    }

    public void AllocateScore()
    {
        // Add the specified kill score to the player's total score
        _scoreController.AddScore(_killScore);
    }
}
