using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public bool isRotating;
    private Animator anim;

    public bool shouldMove;

    public Transform[] movingPoints;
    public Transform points;
    private int curPoint;
    public float moveSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();

        points.parent = null;
    }

    void Update()
    {
        anim.SetBool("IsMoving", isRotating);

        if(shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, movingPoints[curPoint].position, moveSpeed * Time.deltaTime);
            if(transform.position == movingPoints[curPoint].position)
            {
                curPoint++;
                if(curPoint >= movingPoints.Length)
                {
                    curPoint = 0;
                }
            }
        }
    }
}
