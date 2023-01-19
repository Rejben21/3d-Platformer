using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool shouldOpen;

    public Transform theDoor, openRot;
    public float openSpeed;

    private Quaternion startRot;

    public ButtonController button;
    
    void Start()
    {
        startRot = theDoor.rotation;
    }

    void Update()
    {
        if(shouldOpen || button.isPressed)
        {
            theDoor.rotation = Quaternion.Slerp(theDoor.rotation, openRot.rotation, openSpeed * Time.deltaTime);
        }
        else
        {
            theDoor.rotation = Quaternion.Slerp(theDoor.rotation, startRot, openSpeed * Time.deltaTime);
        }
    }
}
