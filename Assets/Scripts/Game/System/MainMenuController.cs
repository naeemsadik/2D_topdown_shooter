using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        highScoreText.text = $"High Score: {GameStateManager.LoadHighScore()}";

        if (!GameStateManager.HasSavedGame())
        {
            continueButton.interactable = false;
        }
    }

    public void NewGame()
    {
        GameStateManager.DeleteSavedGame();
        SceneManager.LoadScene("Game");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Game");
    }
}