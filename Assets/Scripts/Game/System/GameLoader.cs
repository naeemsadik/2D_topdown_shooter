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
            
            // Note: We no longer automatically clear saved game data after loading
            // This allows players to continue from their saved position multiple times
            // Saved game data is now only cleared when starting a new game
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
