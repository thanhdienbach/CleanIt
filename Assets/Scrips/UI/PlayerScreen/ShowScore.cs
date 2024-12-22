using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI garbageText;
    [SerializeField] public TextMeshProUGUI plasticText;
    [SerializeField] public TextMeshProUGUI metalText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadInfo();
    }
    void LoadInfo()
    {
        garbageText.text = "" + PlayerEvent.Instance.countGarbage;
        plasticText.text = "" + PlayerEvent.Instance.countPlastic;
        metalText.text = "" + PlayerEvent.Instance.countMetal;
    }
    void UpDateScore()
    {
        
    }
}
