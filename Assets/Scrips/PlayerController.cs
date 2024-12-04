using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public FixedJoystick joystick;
    
    public float speed = 15.0f;
    public Vector3 direction;
    private Rigidbody rb;

    private int countDir;
    private int countKey;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI countK;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countDir = 0;
        countKey = 0;
        SetCountText();
        SetCountKey();
    }

    void FixedUpdate()
    {
        direction = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        rb.AddForce (direction * speed * Time.deltaTime,ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dirty"))
        {
            other.gameObject.SetActive(false);
            countDir += 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            countKey += 1;
            SetCountKey();
        }
        if (other.gameObject.CompareTag("Door"))
        {
            other.gameObject.SetActive(true);
            SceneManager.LoadScene(1);
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + countDir.ToString();
    }
    void SetCountKey()
    {
        countK.text = "Key:  " + countKey.ToString();
    }
}
