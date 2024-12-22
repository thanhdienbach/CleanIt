using UnityEngine;
using TMPro;
using NUnit.Framework;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    public PopupManager popupManager;
    public AudioSource backAudio;    
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        popupManager.ShowPopup<MenuPopup>();
        popupManager.ShowPopup<MainMenuPopup>();
        popupManager.ShowPopup<WaitingPopup>();
        backAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
