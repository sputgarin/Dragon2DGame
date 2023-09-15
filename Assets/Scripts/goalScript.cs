using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class goalScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("You win!");
        }
    }
}
