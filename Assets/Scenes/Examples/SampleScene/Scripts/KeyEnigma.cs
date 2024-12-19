using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject keyObject;         
    public GameObject boardObject;      
    private bool hasKey = false;          
    
    [SerializeField] private float pickupRange = 2f; 
    [SerializeField] private float useRange = 2f;    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickupKey();
        }

        if (Input.GetKeyDown(KeyCode.E) && hasKey)
        {
            TryInsertKey();
        }
    }

    void TryPickupKey()
    {
        if (keyObject != null && Vector3.Distance(transform.position, keyObject.transform.position) <= pickupRange)
        {
            
            hasKey = true;
            Destroy(keyObject); // Remove the key from the scene
            Debug.Log("Key picked up!");
        }
        else
        {
            Debug.Log("No key nearby to pick up.");
        }
    }

    void TryInsertKey()
    {
        if (boardObject != null && Vector3.Distance(transform.position, boardObject.transform.position) <= useRange)
        {
            ButtonLedManager buttonLedManager = FindObjectOfType<ButtonLedManager>();
            if (buttonLedManager != null)
            {
                buttonLedManager.keyInserted = true;
                Debug.Log("Key inserted into the board!");
            }
            hasKey = false;
            
        }
        else
        {
            Debug.Log("Too far from the board to use the key.");
        }
    }
}