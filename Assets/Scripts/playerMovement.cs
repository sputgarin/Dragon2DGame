using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Moving");
    }
    
    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }

    
}
