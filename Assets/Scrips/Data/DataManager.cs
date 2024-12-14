using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class DataManager : MonoBehaviour
{

    // Singleton để đảm bảo chỉ có một DataManager trong game
    public static DataManager Instance { get; private set; }

    // Đường dẫn file lưu trữ
    private string filePath;

    // Biến lấy dữ liệu từ file lưu trữ json
    public PlayerData loadData;


    private void Awake()
    {
        // Đảm bảo Singletan
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
        filePath = Application.persistentDataPath + "/playerdata.Json";
        PlayerData newData = new PlayerData("First Player", 1, 0);
        SavePlayerData(newData);
        InitializeData();
    }

    void Update()
    {

    }

    // Hàm khởi tạo dữ liệu hoặc load từ file /JSON
    public void InitializeData()
    {
        loadData =  LoadPlayerData();
        LoadGameSettings();
    }

    // Hàm lưu dữ liệu người chơi
    public void SavePlayerData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Dữ liệu đã được lưu tại: " + filePath);
    }

    // Hàm load dữ liệu người chơi
    public PlayerData LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.Log("File không tồn tại");
            return null;
        }
    }

    public void LoadGameSettings()
    {
        
    }

}

[System.Serializable]
public class PlayerData
{
    public string PlayerName;
    public int Levle;
    public int Score;

    public PlayerData(string _PlayerName, int _Level, int _Score)
    {
        PlayerName = _PlayerName;
        Levle = _Level;
        Score = _Score;
    }
}

[System.Serializable]
public class GameSettings
{
    public float Volum;
    public float TouchSensitivity;

    public GameSettings(float _Volum, float _TouchSensitivity)
    {
        Volum = _Volum;
        TouchSensitivity = _TouchSensitivity;
    }
}










//public class PlayerData
//{

//}
//public class LevelConfig
//{
//    public List<int> listSpawnItemsId;
//}
//public class GameConfig
//{
//    public Dictionary<int, ItemConfig> dictItems;
//}

//public class InventoryData
//{
//    /// <summary>
//    /// key : item id
//    /// </summary>
//    public Dictionary<int, List<ItemData>> dictItemData;
//}
//public class ItemConfig
//{
//    public float spawnChance;
//    public int id;
//}

//public class ItemData {
//    public int id;
//    public bool isUnlockable;
//}


