using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedCylinderController : MonoBehaviour
{
    private Animator anim;
    public Transform model;

    public bool shouldRotate;
    public bool shouldMove;

    public Transform[] points;
    private int curPoint;
    public Transform movingPoints;
    public float moveSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();

        movingPoints.parent = null;
    }

    void Update()
    {
        anim.SetBool("ShouldRotate", shouldRotate);

        if(shouldMove)
        {
            model.position = Vector3.MoveTowards(model.position, points[curPoint].position, moveSpeed * Time.deltaTime);
            if (model.position == points[curPoint].position)
            {
                curPoint++;
                if (curPoint >= points.Length)
                {
                    curPoint = 0;
                }
            }
        }
    }
}
