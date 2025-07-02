using UnityEngine;

/// <summary>
/// Handles loading saved game state when the game scene starts.
/// Attach this to a GameObject in your game scene.
/// </summary>
public class GameLoader : MonoBehaviour
{
    void Start()
    {
        LoadSavedGame();
    }
    
    private void LoadSavedGame()
    {
        if (GameStateManager.HasSavedGame())
        {
            var (savedScore, savedPosition) = GameStateManager.LoadGame();
            
            // Restore player position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = savedPosition;
                Debug.Log($"Player position restored to: {savedPosition}");
            }
            
            // Restore score
            ScoreController scoreController = FindObjectOfType<ScoreController>();
            if (scoreController != null)
            {
                scoreController.SetScore(savedScore);
                Debug.Log($"Score restored to: {savedScore}");
            }
            
            // Clear the saved game data after loading
            ClearSavedGameData();
        }
    }
    
    private void ClearSavedGameData()
    {
        PlayerPrefs.DeleteKey("CurrentScore");
        PlayerPrefs.DeleteKey("PlayerPosX");
        PlayerPrefs.DeleteKey("PlayerPosY");
        PlayerPrefs.DeleteKey("PlayerPosZ");
        PlayerPrefs.Save();
    }
}
