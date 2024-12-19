using ECM2.Examples.FirstPerson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combi : MonoBehaviour
{
    private bool isInTrigger = false;
    private bool CombiEquiped = false;
    public Transform otherTransform;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEntered");
        if (other.gameObject.CompareTag("Combi"))
        {
            isInTrigger = true;
        }

        else if (other.gameObject.CompareTag("flaque"))
        {
            if(!CombiEquiped)
            transform.position = otherTransform.position;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Combi"))
        {
            isInTrigger = false;
        }
    }

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("InputDetected");
                CombiEquiped = true;
            }
        }
    }
}