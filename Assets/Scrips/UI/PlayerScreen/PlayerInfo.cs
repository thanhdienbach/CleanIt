using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public TextMeshProUGUI playerInfoText;
    void Start()
    {
        playerInfoText.text = DataManager.Instance.LoadString("Player Name", "Error");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
