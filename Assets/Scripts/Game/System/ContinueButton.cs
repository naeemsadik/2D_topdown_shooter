using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(TaskOnClick);
        }
    }

    void TaskOnClick()
    {
        MainMenuController controller = FindObjectOfType<MainMenuController>();
        if (controller != null)
        {
            controller.StartGame();
        }
    }
}