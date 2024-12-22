using UnityEngine;
using UnityEngine.UI;

public class ExitPanle : MonoBehaviour
{
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    void Start()
    {
        yesButton.onClick.AddListener(ExitGame);
        noButton.onClick.AddListener(ExtendGame);
    }

    void ExitGame()
    {
        Application.Quit();
    }
    void ExtendGame()
    {
        UIManager.Instance.popupManager.HidePopup<ExitPopup>();
    }
}
