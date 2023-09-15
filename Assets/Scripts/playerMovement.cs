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
    
    // Initialize the animator.
    private Animator anim;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsLanded = Animator.StringToHash("isLanded");

    private bool isTouchingGround = false;

    // Get the rigidbody on awake.Get the animator compmonent from the dragon.
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Read the input value from the context.
        moveInput = context.ReadValue<Vector2>();
    
        // Apply the movement logic based on the input.
        // Use moveInput.x for horizontal movement and moveInput.y for vertical movement.
        rb.velocity = new Vector3(moveInput.x * moveSpeed, moveInput.y * moveSpeed, rb.velocity.z);

        // Log a message for testing purposes.
        // Debug.Log("Horizontal Input: " + moveInput.x);
        // Debug.Log("Vertical Input: " + moveInput.y);
    }
    
    
    // Space button to fire.
    public void Fire(InputAction.CallbackContext context)
    {
        // Debug.Log("Fire");
    }

    // Escape key opens pause menu
    public void PauseMenu(InputAction.CallbackContext context)
    {
        // Debug.Log("PauseMenuOpened");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isTouchingGround = true;
            anim.SetBool(IsLanded, true);
            Debug.Log("Player is grounded!");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isTouchingGround = false;
            anim.SetBool(IsLanded, false);
            Debug.Log("NO GROUND!");
        }
    }

    private void Update()
    {
        if (rb.velocity.x != 0 && isTouchingGround == true)
        {
            anim.SetBool(IsWalking, true);
            Debug.Log("Moving");
        }
        else
        {
            anim.SetBool(IsWalking, false);
        }
    }
}
