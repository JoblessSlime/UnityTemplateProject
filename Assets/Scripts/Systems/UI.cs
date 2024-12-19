using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private bool UIactivated = false;
    public GameObject panel;
    public Transform fifthFloor;
    public Transform fourthFloor;
    public Transform thirdFloor;
    public Transform secondFloor;
    public Transform firstFloor;
    public Transform outside;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FirstFloor();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SecondFloor();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ThirdFloor();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            FourthFloor();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            FithFloor();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Outside();
        }
    }

    public void FirstFloor ()
    {
        transform.position = firstFloor.position;
    }

    public void SecondFloor()
    {
        transform.position = secondFloor.position;
    }

    public void ThirdFloor()
    {
        transform.position = thirdFloor.position;
    }

    public void FourthFloor()
    {
        transform.position = fourthFloor.position;
    }

    public void FithFloor()
    {
        transform.position = fifthFloor.position;
    }
    
    public void Outside()
    {
        transform.position = outside.position;
    }
}
