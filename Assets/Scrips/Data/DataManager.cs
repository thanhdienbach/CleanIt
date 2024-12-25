using UnityEngine;

public class DataManager
{
    // Biến static lưu trữ instance duy nhất
    public static DataManager _instance;

    // Object khóa để đảm bảo thread-safety 
    private static readonly object _lock = new object();

    // Thuộc tính singleton
    public static DataManager Instance
    {
        get
        {
            if (_instance == null) // Kiểm tra nếu instance chưa được khởi tại
            {
                lock (_lock) // Đảm bảo chỉ có môt thread được truy cập
                {
                    if (_instance == null)
                    {
                        _instance = new DataManager();
                    }
                }
            }
            return _instance;
        }
    }

    // Constructer để ngăn khởi tạo từ bên ngoài
    private DataManager() { }

    public void SavePlayerData(string playerName, int exp, int garbageCount, int plasticCount, int metalCount)
    {
        PlayerPrefs.SetString("Player Name", playerName);
        PlayerPrefs.SetInt("Exp", exp);
        PlayerPrefs.SetInt("Garbage Count", garbageCount);
        PlayerPrefs.SetInt("Plastic Count", plasticCount);
        PlayerPrefs.SetInt("Metal Count", metalCount);
        PlayerPrefs.Save();
    }
    // Lưu dữ liệu số
    public void SaVeInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save(); // Đảm bảo dữ liệu được lưu vào store
    }

    // Load dữ liệu số
    public int LoadInt(string key, int defaultValue = 0)
    {
        if (PlayerPrefs.HasKey(key))
        {
            int value = PlayerPrefs.GetInt(key);
            return value;
        }
        else
        {
            Debug.LogWarning($"{key} not found. Returning default value: {defaultValue}");
            return defaultValue;
        }
    }

    // Lưu dữ liệu chuổi
    public void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save(); 
    }

    // Load dữ liệu chuổi
    public string LoadString(string key, string defaultValue)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string value = PlayerPrefs.GetString(key);
            return value;
        }
        else
        {
            return defaultValue;
        }
    }

}



