using UnityEngine;

public class EnigmaButton : MonoBehaviour
{
    [SerializeField] private int digit; // The digit this button represents
    [SerializeField] private EnigmaMachine enigmaMachine; // Reference to the EnigmaMachine script

    private void OnMouseDown()
    {
        if (enigmaMachine != null)
        {
            //enigmaMachine.EnterDigit(digit);
        }
    }
}