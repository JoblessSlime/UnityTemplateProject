using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnigmaMachine : MonoBehaviour
{
    [SerializeField] private List<GameObject> cylinders; 
    [SerializeField] private TextMeshPro screenText;
    [SerializeField] private string correctPassword = "12345";
    public GameObject mainDoor;


    private string enteredPassword = "";

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Clicked on: " + hit.collider.name);

                if (cylinders.Contains(hit.collider.gameObject))
                {
                    HandleCylinderClick(hit.collider.gameObject);
                }
            }
        }
    }

    private void HandleCylinderClick(GameObject cylinder)
    {
        enteredPassword += cylinder.name; 
        UpdateScreenText(enteredPassword);

        if (enteredPassword.Length >= correctPassword.Length)
        {
            CheckPassword();
        }
    }

    private void UpdateScreenText(string text)
    {
        if (screenText != null)
        {
            screenText.text = text;
        }
        else
        {
            Debug.LogWarning("Screen text is not assigned!");
        }
    }

    private void CheckPassword()
    {
        if (enteredPassword == correctPassword)
        {
            Debug.Log("Correct password entered! Puzzle solved.");
            UpdateScreenText("ACCESS GRANTED");
            mainDoor.SetActive(false);

        }
        else
        {
            Debug.Log("Incorrect password. Try again.");
            UpdateScreenText("ACCESS DENIED");
            enteredPassword = ""; 
        }
    }
}
