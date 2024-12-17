using UnityEngine;

public class EngineManager : MonoBehaviour
{
    public GameObject engineObject;         
    public GameObject doorObject;      
    private bool hasObject = false;          
    
    [SerializeField] private float pickupRange = 2f; 
    [SerializeField] private float useRange = 2f;    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickupObj();
        }

        if (Input.GetKeyDown(KeyCode.E) && hasObject)
        {
            TryInsertObj();
        }
    }

    void TryPickupObj()
    {
        if (engineObject != null && Vector3.Distance(transform.position, engineObject.transform.position) <= pickupRange)
        {
            
            hasObject = true;
            Destroy(engineObject); // Remove the key from the scene
            Debug.Log("Key picked up!");
        }
        else
        {
            Debug.Log("No key nearby to pick up.");
        }
    }

    void TryInsertObj()
    {
        if (doorObject != null && Vector3.Distance(transform.position, doorObject.transform.position) <= useRange)
        {
            ButtonLedManager buttonLedManager = FindObjectOfType<ButtonLedManager>();
            if (buttonLedManager != null)
            {
                buttonLedManager.reactorComplete = true;
                Debug.Log("Key inserted into the board!");
            }
            hasObject = false;
            
        }
        else
        {
            Debug.Log("Too far from the board to use the key.");
        }
    }
}