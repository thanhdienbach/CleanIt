using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanle : MonoBehaviour
{

    [SerializeField] Button continueGameButton;
    [SerializeField] Button newGameButton;
    [SerializeField] Button loadGameButton;
    [SerializeField] Button optionButton;
    [SerializeField] Button exitPanle;
    
    void Start()
    {
        continueGameButton.onClick.AddListener(HideAllMainMenuPanle);
        continueGameButton.onClick.AddListener(ChangeGameStateToPlaying);
        newGameButton.onClick.AddListener(HideAllChildrenPanle);
        newGameButton.onClick.AddListener(ShowCreatPlayerPanle);
        loadGameButton.onClick.AddListener(HideAllChildrenPanle);
        loadGameButton.onClick.AddListener(ShowPlayerListPanle);
        optionButton.onClick.AddListener(HideAllChildrenPanle);
        optionButton.onClick.AddListener(ShowSettingPanle);
        exitPanle.onClick.AddListener(HideAllChildrenPanle);
        exitPanle.onClick.AddListener(ShowExitPanle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeGameStateToPlaying()
    {
        UIManager.Instance.popupManager.ShowPopup<GameScenePopup>();
        GameManager.Instance.ChangeState(GameState.Playing);
    }
    void HideAllMainMenuPanle()
    {
        UIManager.Instance.popupManager.HideAllPopup();
    }
    void HideAllChildrenPanle()
    {
        UIManager.Instance.popupManager.HidePopup<CreatNewPlayerPopup>();
        UIManager.Instance.popupManager.HidePopup<PlayerListPopup>();
        UIManager.Instance.popupManager.HidePopup<OptionPopup>();
        UIManager.Instance.popupManager.HidePopup<ExitPopup>();
    }
    void ShowCreatPlayerPanle()
    {
        UIManager.Instance.popupManager.ShowPopup<CreatNewPlayerPopup>();
    }
    void ShowPlayerListPanle()
    {
        UIManager.Instance.popupManager.ShowPopup<PlayerListPopup>();
    }
    void ShowSettingPanle()
    {
        UIManager.Instance.popupManager.ShowPopup<OptionPopup>();
    }
    void ShowExitPanle()
    {
        UIManager.Instance.popupManager.ShowPopup<ExitPopup>();
    }
}
