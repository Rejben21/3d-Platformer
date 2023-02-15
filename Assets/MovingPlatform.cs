using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    private int curPoint;
    public float moveSpeed;

    void Start()
    {
        curPoint = 0;

        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[curPoint].position, moveSpeed * Time.deltaTime);

        if(transform.position == points[curPoint].position)
        {
            curPoint++;
            if(curPoint >= points.Length)
            {
                curPoint = 0;
            }
        }
    }
}
