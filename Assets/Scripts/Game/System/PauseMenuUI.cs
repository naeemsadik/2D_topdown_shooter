using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages the pause menu UI elements and their interactions.
/// This script should be attached to the pause menu canvas or panel.
/// </summary>
public class PauseMenuUI : MonoBehaviour
{
    [Header("UI Buttons")]
    public Button continueButton;
    public Button saveButton;
    public Button saveAndQuitButton;
    public Button mainMenuButton;
    
    [Header("Feedback Text")]
    public TMP_Text feedbackText;
    
    private GameMenu gameMenu;
    
    void Start()
    {
        gameMenu = FindObjectOfType<GameMenu>();
        SetupButtons();
    }
    
    private void SetupButtons()
    {
        if (continueButton != null)
            continueButton.onClick.AddListener(() => gameMenu.ResumeGame());
            
        if (saveButton != null)
            saveButton.onClick.AddListener(OnSaveClicked);
            
        if (saveAndQuitButton != null)
            saveAndQuitButton.onClick.AddListener(() => gameMenu.SaveAndQuit());
            
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(() => gameMenu.ReturnToMainMenu());
    }
    
    private void OnSaveClicked()
    {
        gameMenu.SaveGame();
        ShowFeedback("Game Saved!");
    }
    
    private void ShowFeedback(string message)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.gameObject.SetActive(true);
            
            // Hide feedback after 2 seconds
            Invoke(nameof(HideFeedback), 2f);
        }
    }
    
    private void HideFeedback()
    {
        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false);
        }
    }
}
