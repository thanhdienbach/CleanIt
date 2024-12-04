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

    private int count;
    public TextMeshProUGUI countText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
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
            count += 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Door"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}
