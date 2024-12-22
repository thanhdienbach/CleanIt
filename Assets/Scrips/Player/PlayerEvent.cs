using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvent : MonoBehaviour
{

    public static PlayerEvent Instance { get; private set; }

    public UnityEvent onCollisionEnterEvent;
    public bool onCollisionEnterEventStatus;
    public string eventType;

    public int playerExp;
    public int countGarbage;
    public int countPlastic;
    public int countMetal;

    public AudioSource clearAudio;

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
        onCollisionEnterEvent = new UnityEvent();

        clearAudio = GetComponent<AudioSource>();

        onCollisionEnterEvent.AddListener(UpdataScore);

        onCollisionEnterEvent.AddListener(VFX);
    }

    void Update()
    {
        if (onCollisionEnterEventStatus == true)
        {
            onCollisionEnterEvent.Invoke();
            onCollisionEnterEventStatus = false;
        }
    }
    public void LoadScore()
    {
        countGarbage = DataManager.Instance.LoadInt("Garbage Count", 0);
        countPlastic = DataManager.Instance.LoadInt("Plastic Count", 0);
        countMetal = DataManager.Instance.LoadInt("Metal Count", 0);
    }
    public void SavePlayerData()
    {
        DataManager.Instance.SavePlayerData(DataManager.Instance.LoadString("Player Name","Error"),playerExp, countGarbage,countPlastic,countMetal);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Untagged"))
        {
            eventType = collision.gameObject.tag;
            onCollisionEnterEventStatus = true;
            Destroy(collision.gameObject);
        }
    }

    void UpdataScore()
    {
        if (eventType == "Garbage")
        {
            countGarbage += 1;
            playerExp += 1;
        }
        else if (eventType == "Plastic")
        {
            countPlastic += 1;
            if(playerExp + 3 >= 20)
            {
                playerExp = 20;
            }
            else
            {
                playerExp += 3;
            }
            
        }
        else if (eventType == "Metal")
        {
            countMetal += 1;
            if (playerExp + 10 >= 20)
            {
                playerExp = 20;
            }
            else
            {
                playerExp += 10;
            }
        }  
    }

    void VFX()
    {
        clearAudio.Play();
    }
}
