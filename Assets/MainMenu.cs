using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
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
