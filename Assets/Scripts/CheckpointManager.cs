using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public Checkpoint[] checkpoints;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
    }
}
