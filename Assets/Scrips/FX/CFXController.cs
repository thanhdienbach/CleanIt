using UnityEngine;

public class CFXController : MonoBehaviour
{
    public GameObject clearEffect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(clearEffect, transform.position, Quaternion.identity);
        }
    }
}
