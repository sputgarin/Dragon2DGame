using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 5f;
    
    // Adding a variable for the Rigidbody
    private Rigidbody rb;

    // Adding a vector 2 variable for the move input.
    private Vector2 moveInput;

    // Get the rigidbody on awake.
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Read the input value from the context.
        moveInput = context.ReadValue<Vector2>();
    
        // Apply the movement logic based on the input.
        // Use moveInput.x for horizontal movement and moveInput.y for vertical movement.
        rb.velocity = new Vector3(moveInput.x * moveSpeed, moveInput.y * moveSpeed, rb.velocity.z);

        // Log a message for testing purposes.
        Debug.Log("Horizontal Input: " + moveInput.x);
        Debug.Log("Vertical Input: " + moveInput.y);
    }
    
    
    
    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }

    public void PauseMenu(InputAction.CallbackContext context)
    {
        Debug.Log("PauseMenuOpened");
    }

    
}
