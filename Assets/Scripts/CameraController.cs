using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [HideInInspector]
    public CinemachineBrain cMBrain;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cMBrain = GetComponent<CinemachineBrain>();
    }

    void Update()
    {
        
    }
}
