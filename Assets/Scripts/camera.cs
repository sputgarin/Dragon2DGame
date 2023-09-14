using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{

    [SerializeField]
    private float cameraSpeed = 5f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        Vector3 newPosition = currentPosition + Vector3.right * (cameraSpeed * Time.deltaTime);

        transform.position = newPosition;
    }
}
