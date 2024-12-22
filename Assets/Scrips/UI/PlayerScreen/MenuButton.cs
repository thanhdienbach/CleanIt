using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] Button menuButton;
    void Start()
    {
        menuButton.onClick.AddListener(ShowMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowMenu()
    {
        UIManager.Instance.popupManager.HideAllPopup();
        UIManager.Instance.popupManager.ShowPopup<MenuPopup>();
        UIManager.Instance.popupManager.ShowPopup<MainMenuPopup>();
        UIManager.Instance.popupManager.ShowPopup<WaitingPopup>();
        GameManager.Instance.ChangeState(GameState.Paused);
    }
}
