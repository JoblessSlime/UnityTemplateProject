using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonterEchelle : MonoBehaviour
{
    public float speed = 2f;
    private bool isInTrigger = false;
    private bool isClimbing = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEntered");
        if (other.gameObject.CompareTag("Echelle"))
        {
            isInTrigger = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Echelle"))
        {
            isClimbing = false ;
            isInTrigger =  false ;
            this.GetComponent<Rigidbody>().useGravity = true ;
        }
    }

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("InputDetected");
                isClimbing = !isClimbing;
                if (isClimbing)
                    this.GetComponent<Rigidbody>().useGravity = false;
                else
                    this.GetComponent<Rigidbody>().useGravity = true;

            }
        }
        if (isClimbing)
        {
            MonterDescendre(1);
        }
    }

    private void MonterDescendre(int direction)
    {
        transform.Translate(0, direction * speed * Time.deltaTime, 0);
    }
}
