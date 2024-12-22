using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatNewPlayerPanle : MonoBehaviour
{
    [SerializeField] Button creatButton;
    [SerializeField] TMP_InputField playerNameField;
    [SerializeField] TextMeshProUGUI playerInfo;
    
    void Start()
    {
        creatButton.onClick.AddListener(CreatPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreatPlayer()
    {
        DataManager.Instance.SaveString("Player Name", playerNameField.text);
        DataManager.Instance.SavePlayerData(DataManager.Instance.LoadString("Player Name", "Error"),0,0,0,0);
        UIManager.Instance.popupManager.HidePopup<CreatNewPlayerPopup>();
        UIManager.Instance.popupManager.ShowPopup<PlayerListPopup>();
    }
}
