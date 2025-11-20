using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;        
    public float runSpeed = 8f;         
    public float jumpForce = 5f;        
    public float gravity = -9.81f;      

    [Header("Component References")]
    public CharacterController controller; 
    public Transform cameraTransform;     

    private Vector3 velocity;              
    private bool isGrounded;               
    private float currentSpeed;
    private float initialY;            

    private void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();

        currentSpeed = moveSpeed;
        transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
        
        //if (controller != null)
        //{
        //    controller.Rotate(Vector3.up * -90f);
        //}
    }

    void Update()
    {
        // Ground check
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.1f; // Keeps the player grounded
        }

        // Get WASD input
        float x = 0f;
        float z = 0f;
        if (Input.GetKey(KeyCode.W)) z = 1f;
        if (Input.GetKey(KeyCode.S)) z = -1f;
        if (Input.GetKey(KeyCode.A)) x = -1f;
        if (Input.GetKey(KeyCode.D)) x = 1f;

        // Move relative to the camera’s orientation
        Vector3 move = cameraTransform.right * x + cameraTransform.forward * z;
        move.y = 0f; // Prevent vertical movement
        move.Normalize();

        // Run (hold Left Shift)
        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = runSpeed;
        else
            currentSpeed = moveSpeed;

        controller.Move(move * currentSpeed * Time.deltaTime);

        // Jump (Space key)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
       
        if (isGrounded && transform.position.y > initialY)
        {
            Vector3 pos = transform.position;
            pos.y = initialY;
            transform.position = pos;
        }
    }
}