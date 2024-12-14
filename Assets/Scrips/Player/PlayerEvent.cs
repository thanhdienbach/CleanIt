using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvent : MonoBehaviour
{
    
    public UnityEvent onCollisionEnterEvent;
    public bool onCollisionEnterEventStatus;
    public string eventType;

    public int countGarbage;
    public int countPlastic;
    public int countMetal;

    public AudioSource clearAudio;

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
        }
        else if (eventType == "Plastic")
        {
            countPlastic += 1;
        }
        else if (eventType == "Metal")
        {
            countMetal += 1;
        }
    }

    void VFX()
    {
        clearAudio.Play();
    }
}
