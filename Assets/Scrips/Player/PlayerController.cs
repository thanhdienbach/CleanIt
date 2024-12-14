using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody playerRigidbody;
    public float playerSpeed = 60.0f;
    public Vector3 playerDirection;
    public Joystick joystick;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        playerDirection = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        playerRigidbody.AddForce(playerDirection * playerSpeed * Time.deltaTime, ForceMode.Impulse);
    }

}
