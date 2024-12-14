using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Singleton đảm bảo chỉ có một UIManager trong game
    public static UIManager Instance { get; private set; }

    public TextMeshProUGUI garbageText;
    public TextMeshProUGUI plasticText;
    public TextMeshProUGUI metalText;
    public TextMeshProUGUI playerInfoText;

    private void Awake()
    {
        // Đảm bảo Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không bị hũy khi chuyển sence
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        ShowTextToUI();
    }

    void ShowTextToUI()
    {
        playerInfoText.text = DataManager.Instance.loadData.PlayerName + " - Lv." + DataManager.Instance.loadData.Levle;
    }
}
