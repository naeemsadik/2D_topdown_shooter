using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI References")]
    public Button continueButton;
    
    void Start()
    {
        // Enable/disable continue button based on saved game availability
        if (continueButton != null)
        {
            continueButton.interactable = GameStateManager.HasSavedGame();
        }
    }
    
    public void PlayGame() {
        // Clear any existing save data when starting a new game
        GameStateManager.ClearSavedGame();
        SceneManager.LoadSceneAsync(1);
    }
    
    public void ContinueGame() {
        if (GameStateManager.HasSavedGame())
        {
            SceneManager.LoadSceneAsync(1); // Load game scene
        }
        else
        {
            Debug.Log("No saved game found!");
        }
    }

    public void QuitGame() {
        Application.Quit();
    }

    
}
