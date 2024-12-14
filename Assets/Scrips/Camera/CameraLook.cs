using UnityEngine;

public class CameraLook : MonoBehaviour
{

    private float XMove;
    private float YMove;
    private float XRotation;
    [SerializeField] private Transform playerBody;
    public Vector2 lockAxis;

    void Start()
    {
        
    }

    void Update()
    {
        XMove = lockAxis.x;
        YMove = lockAxis.y;
        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -15, 0);

        transform.localRotation = Quaternion.Euler(XRotation,0,0);
        playerBody.Rotate(Vector3.up * XMove);
    }
}
