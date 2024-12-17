using ECM2.Examples.FirstPerson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonterEchelle : MonoBehaviour
{
    public float speed = 2f;
    private bool isInTrigger = false;
    private bool isClimbing = false;
    public FirstPersonCharacter firstPersonCharacter;

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
            isClimbing = false;
            isInTrigger = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            firstPersonCharacter.gravityScale = 1;
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
                {
                    this.GetComponent<Rigidbody>().useGravity = false;
                    firstPersonCharacter.gravityScale = 0;
                    Debug.Log("YAAYYYYYYY");
                }
                else
                {
                    this.GetComponent<Rigidbody>().useGravity = true;
                    firstPersonCharacter.gravityScale = 1;
                }

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