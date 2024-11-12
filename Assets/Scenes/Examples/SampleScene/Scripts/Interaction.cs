using System.Collections;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    // The color to set the object when clicked
    private Color selectedColor = Color.red;

    // The duration the color stays changed
    private float colorChangeDuration = 2f;

    // Maximum distance for interaction
    public float maxInteractionDistance = 3f;

    // Reference to the currently selected object
    private GameObject selectedObject;

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            HandleObjectClick();
        }
    }

    void HandleObjectClick()
    {
        // Create a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Cast the ray and check if it hits an object with a collider
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object is tagged as "Interactable"
            if (hit.collider.CompareTag("Interactable"))
            {
                // Check if the player is within the max interaction distance
                float distance = Vector3.Distance(transform.position, hit.collider.transform.position);
                if (distance <= maxInteractionDistance)
                {
                    // Change color of the clicked object temporarily
                    selectedObject = hit.collider.gameObject;
                    StartCoroutine(ChangeColorTemporarily(selectedObject, selectedColor, colorChangeDuration));
                }
                else
                {
                    Debug.Log("Object is too far to interact with.");
                }
            }
        }
    }

    IEnumerator ChangeColorTemporarily(GameObject obj, Color color, float duration)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        
        // If the object has a Renderer, change its color
        if (renderer != null)
        {
            Color originalColor = renderer.material.color; // Save the original color
            renderer.material.color = color; // Set the color to the selected color

            yield return new WaitForSeconds(duration); // Wait for the specified duration

            renderer.material.color = originalColor; // Reset to the original color
        }
    }
}