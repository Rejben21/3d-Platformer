using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public bool isMoving;
    private Animator anim;

    public bool shouldMove;

    public Transform[] movingPoints;
    private int curPoint;
    public float moveSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("IsMoving", isMoving);

        if(shouldMove)
        {

        }
    }
}
