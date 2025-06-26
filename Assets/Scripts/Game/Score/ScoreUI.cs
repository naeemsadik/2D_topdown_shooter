using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For using TextMeshPro UI components


public class ScoreUI : MonoBehaviour
{
    // Reference to the TextMeshPro text component that displays the score
    private TMP_Text _scoreText;

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Get the TMP_Text component attached to the same GameObject
        _scoreText = GetComponent<TMP_Text>();
    }

    // Updates the score display on the UI
    public void UpdateScore(ScoreController scoreController)
    {
        // Set the text to show the current score from the ScoreController
        _scoreText.text = $"Score: {scoreController.Score}";
    }

}
