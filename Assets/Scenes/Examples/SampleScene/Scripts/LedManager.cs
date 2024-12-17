using System;
using System.Collections;
using UnityEngine;

public class ButtonLedManager : MonoBehaviour
{
    public GameObject[] leds; 
    public Material redMaterial;
    public Material greenMaterial;
    [SerializeField] private GameObject winPopup;
    [SerializeField] private GameObject keyPopup; 
    [SerializeField] private GameObject reactorPopup; 
    public float displayDuration = 3f; 

    private bool[] ledStates;

    public bool reactorComplete = false; 
    public bool keyInserted = false;    

    void Start()
    {
        ledStates = new bool[leds.Length];
        ledStates[0] = false; // Red
        ledStates[1] = false; // Red
        ledStates[2] = true;  // Green

        UpdateLedColors();
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
    }

    public void OnButtonPressed(int buttonIndex)
    {
        if (!reactorComplete || !keyInserted)
        {
            Debug.Log("Conditions not met: Reactor must be complete and key must be inserted.");
            if (!reactorComplete)
            {
                reactorPopup.SetActive(true); 

            }
            if (!keyInserted)
            {
                keyPopup.SetActive(true); 

            }
            return;
        }

        if (ledStates[buttonIndex]) return; 

        ledStates[buttonIndex] = true;

        for (int i = 0; i < ledStates.Length; i++)
        {
            if (i != buttonIndex && i > buttonIndex )
            {
                ledStates[i] = false; // Turn it red
                break;
            }
        }

        UpdateLedColors();

        CheckWinCondition();
    }

    void UpdateLedColors()
    {
        for (int i = 0; i < leds.Length; i++)
        {
            Renderer renderer = leds[i].GetComponent<Renderer>();
            renderer.material = ledStates[i] ? greenMaterial : redMaterial;
        }
    }

    bool CheckWinCondition()
    {
        foreach (bool state in ledStates)
        {
            if (!state) return false;
        }
        ShowWinPopup();
        return true;
    }

    void ShowWinPopup()
    {
        if (winPopup != null)
        {
            winPopup.SetActive(true); 
        }
    }
    
    IEnumerator HidePopupAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        keyPopup.SetActive(false);
        reactorPopup.SetActive(false);

    }
}