using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public ButtonLedManager buttonLedManager;
    public int buttonIndex; // Set unique index (0, 1, 2) for each button in Inspector

    void OnMouseDown()
    {
        buttonLedManager.OnButtonPressed(buttonIndex);
    }
}
