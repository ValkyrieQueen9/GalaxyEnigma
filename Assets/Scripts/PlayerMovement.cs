using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    public CharacterController controller;
    public float speed = 12f;

    [Header("Gravity")]
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;

    [Header("Jump")]
    public float jumpHeight = 3f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Camera mainCamera;

    Vector3 velocity; //Used for gravity
    bool isGrounded; //Used for gravity
    float xRotation = 0f; //Used for mouse

    void Start()
    {
        //Locks the cursor to the centre of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        #region PlayerMovement - gravity & jump
        
        //Checks if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Resets velocity when player is on the ground
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Getting Inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Creates direction for movement based on which way character is facing
        Vector3 moveDirection = transform.right * x + transform.forward * z;

        //Uses the Move function on the character controller to move using MoveDirection variable
        controller.Move(moveDirection * speed * Time.deltaTime);

        //Creates jump funtion
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Creates a velocity variable to use in gravity
        velocity.y += gravity * Time.deltaTime;

        //Adds the velocity variable using the Move function on the character controller
        controller.Move(velocity * Time.deltaTime);

        #endregion

        #region Mouse Look

        //Gets Inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Creates roation for Y
        xRotation -= mouseY;

        //Stops the player from rotating the camera 360 around itself
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Uses the xRotation variable
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Rotates the player body based on the mouse direction
        playerBody.Rotate(Vector3.up * mouseX);

        #endregion
    }
}

