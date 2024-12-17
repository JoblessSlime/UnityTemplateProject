using UnityEngine;

public class DrawingClickHandler : MonoBehaviour
{
    [SerializeField] private AmongUs enigmaManager;

    private void Start()
    {
        if (enigmaManager == null)
        {
            Debug.LogError("Enigma Manager is not assigned to DrawingClickHandler on " + gameObject.name);
        }
    }

    private void OnMouseDown()
    {
        if (enigmaManager != null)
        {
            enigmaManager.SelectDrawing(gameObject);
        }
    }
}