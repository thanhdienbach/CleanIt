using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerListPanle : MonoBehaviour
{
    [SerializeField] Button playerInfoButton;
    [SerializeField] TextMeshProUGUI playerInfoText;
    [SerializeField] TextMeshProUGUI playerInfoTextGameScene;
    
    void Start()
    {
        playerInfoButton.onClick.AddListener(HideAllMainMenuPanle);
        playerInfoButton.onClick.AddListener(LoadPlayerScene);
    }

    // Update is called once per frame
    void Update()
    {
        playerInfoText.text = DataManager.Instance.LoadString("Player Name", "Error");
    }
    void HideAllMainMenuPanle()
    {
        UIManager.Instance.popupManager.HideAllPopup();
    }
    void LoadPlayerScene()
    {
        UIManager.Instance.popupManager.ShowPopup<GameScenePopup>();
        GameManager.Instance.ChangeState(GameState.Playing);
        playerInfoTextGameScene.text = DataManager.Instance.LoadString("Player Name", "Error");
    }
    
}
