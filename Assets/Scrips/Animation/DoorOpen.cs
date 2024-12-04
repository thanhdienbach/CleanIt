using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    private Animator doorAnimator;


    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("Door_Open");
            }
        }
    }
}