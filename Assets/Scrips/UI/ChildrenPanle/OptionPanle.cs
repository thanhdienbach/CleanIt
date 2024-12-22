using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OptionPanle : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider touchSensitivitySlider;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] TextMeshProUGUI touchSensitivityText;
    [SerializeField] Button saveSettingButton;

    void Start()
    {
        volumeSlider.value = (float)(DataManager.Instance.LoadInt("Volum", 0)/100);
        saveSettingButton.onClick.AddListener(SavePlayerSetting);
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.Instance.backAudio.volume = volumeSlider.value;
        volumeText.text = "Volume: " + Math.Round(volumeSlider.value * 100);
        touchSensitivityText.text = "Touch Sensitivity: " + Math.Round(touchSensitivitySlider.value * 100);
    }
    void SavePlayerSetting()
    {
        DataManager.Instance.SaVeInt("Volum", (int)(volumeSlider.value * 100));
        DataManager.Instance.SaVeInt("TouchSensitivity", (int)(touchSensitivitySlider.value * 100));
    }
}
