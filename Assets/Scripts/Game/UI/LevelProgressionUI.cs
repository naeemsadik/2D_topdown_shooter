using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

/// <summary>
/// Manages level progression UI elements like congratulations messages.
/// This should be attached to a UI Canvas in your game scene.
/// </summary>
public class LevelProgressionUI : MonoBehaviour
{
    [Header("Level Progression UI")]
    public GameObject congratulationsPanel;
    public TMP_Text congratulationsText;
    public Button continueButton;
    
    [Header("Settings")]
    public float displayDuration = 3f; // How long to show the message
    public bool pauseGameDuringMessage = true;
    
    private static LevelProgressionUI instance;
    
    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        // Hide the congratulations panel at start
        if (congratulationsPanel != null)
        {
            congratulationsPanel.SetActive(false);
        }
        
        // Setup continue button
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(HideCongratulationsMessage);
        }
    }
    
    /// <summary>
    /// Shows a congratulations message for level progression.
    /// </summary>
    /// <param name="level">The level that was just completed</param>
    public static void ShowLevelCompletionMessage(int level)
    {
        if (instance != null)
        {
            instance.DisplayCongratulationsMessage(level);
        }
    }
    
    private void DisplayCongratulationsMessage(int completedLevel)
    {
        if (congratulationsPanel != null && congratulationsText != null)
        {
            // Set the congratulations text
            congratulationsText.text = $"Congratulations! You have passed level {completedLevel}";
            
            // Show the panel
            congratulationsPanel.SetActive(true);
            
            // Pause the game if enabled
            if (pauseGameDuringMessage)
            {
                Time.timeScale = 0f;
            }
            
            // Auto-hide after specified duration if no continue button
            if (continueButton == null)
            {
                StartCoroutine(HideAfterDelay());
            }
        }
    }
    
    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSecondsRealtime(displayDuration);
        HideCongratulationsMessage();
    }
    
    public void HideCongratulationsMessage()
    {
        if (congratulationsPanel != null)
        {
            congratulationsPanel.SetActive(false);
        }
        
        // Resume the game if it was paused
        if (pauseGameDuringMessage)
        {
            Time.timeScale = 1f;
        }
    }
}
