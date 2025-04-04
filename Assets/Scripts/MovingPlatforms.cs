using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    private int i;
    void Start()
    {
        transform.position points[startingPoint].position;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i)
        }
    }
}
