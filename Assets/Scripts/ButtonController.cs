using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isPressed;
    public Transform button, pressedPos;
    private Vector3 startPos;

    public bool isOnOff;

    void Start()
    {
        startPos = button.position;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOnOff)
            {
                if (isPressed)
                {
                    button.position = startPos;
                    isPressed = false;
                }
                else
                {
                    button.position = pressedPos.position;
                    isPressed = true;
                }
            }
            else
            {
                if(!isPressed)
                {
                    button.position = pressedPos.position;
                    isPressed = true;
                }
            }
        }
    }
}
