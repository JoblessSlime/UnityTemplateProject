using System;
using System.Collections;
using UnityEngine;

public class ButtonLedManager : MonoBehaviour
{
    // References to LEDs and materials
    public GameObject[] leds; // Assign Led1, Led2, Led3 in the Inspector
    public Material redMaterial;
    public Material greenMaterial;
    public GameObject winPopup; // Assign the popup text GameObject here


    // LED states: true = green, false = red
    private bool[] ledStates;

    void Start()
    {
        // Initialize LED states (2 red, 1 green at the start)
        ledStates = new bool[leds.Length];
        ledStates[0] = false; // Red
        ledStates[1] = false; // Red
        ledStates[2] = false;  // Green

        UpdateLedColors();
        Cursor.visible = true; // Show the cursor
        Cursor.lockState = CursorLockMode.None; // Ensure the cursor is not locked
        
    }
    

    // Called when a button is pressed
    public void OnButtonPressed(int buttonIndex)
    {

        if (ledStates[buttonIndex] == ledStates[0])
        {
            ledStates[buttonIndex] = true;
            
            if (ledStates[2] == true)
            {
                ledStates[1] = false;
            }
        }

        else if (ledStates[buttonIndex] == ledStates[1])
        {
            ledStates[buttonIndex] = true;
            
            if (ledStates[0] == true)
            {
                ledStates[2] = false;
            }
        }

        else if (ledStates[buttonIndex] == ledStates[2])
        {
            ledStates[buttonIndex] = true;
            
        }
        
        UpdateLedColors();

        // Check if the player wins
        if (CheckWinCondition())
        {
            Debug.Log("You Win! All LEDs are green!");
            ShowWinPopup(); // Show the popup

        }
    }

    // Update LED materials based on their states
    void UpdateLedColors()
    {
        for (int i = 0; i < leds.Length; i++)
        {
            Renderer renderer = leds[i].GetComponent<Renderer>();
            renderer.material = ledStates[i] ? greenMaterial : redMaterial;
        }
    }

    // Check if all LEDs are green
    bool CheckWinCondition()
    {
        foreach (bool state in ledStates)
        {
            if (!state) return false;
        }
        return true;
    }
    
    void ShowWinPopup()
    {
        if (winPopup != null)
        {
            winPopup.SetActive(true); // Show the popup
        }
    }
}