using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float _startingPos;
    private float _lengthOfSprites;
    public float amountOfParallax;
    public Camera mainCamera;
    public List<Transform> parallaxLayers; // Assign child objects with SpriteRenderers here.

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the combined length of all child sprites.
        _lengthOfSprites = CalculateCombinedSpriteLength();
        // Get the starting X position of the script's parent object.
        _startingPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = mainCamera.transform.position;
        float temp = position.x * (1 - amountOfParallax);
        float distance = position.x * amountOfParallax;

        // Calculate the new position for the parent object.
        Vector3 newPosition = new Vector3(_startingPos + distance, transform.position.y, transform.position.z);

        // Move the parent object to the new position.
        transform.position = newPosition;

        // Check if the parent object needs to wrap around the sprites.
        if (temp > _startingPos + (_lengthOfSprites / 2))
        {
            _startingPos += _lengthOfSprites;
        }
        else if (temp < _startingPos - (_lengthOfSprites / 2))
        {
            _startingPos -= _lengthOfSprites;
        }
    }

    // Helper function to calculate the combined length of child sprites.
    private float CalculateCombinedSpriteLength()
    {
        float combinedLength = 0f;

        // Iterate through the list of parallax layers.
        foreach (Transform layer in parallaxLayers)
        {
            SpriteRenderer layerRenderer = layer.GetComponent<SpriteRenderer>();
            if (layerRenderer != null)
            {
                combinedLength += layerRenderer.bounds.size.x -3;
            }
        }

        return combinedLength;
    }
}
