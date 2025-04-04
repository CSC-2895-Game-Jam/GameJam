using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    private int i;

    private HashSet<Rigidbody2D> passengers = new HashSet<Rigidbody2D>();
    private Vector2 previousPosition;

    void Start()
    {
        transform.position = points[startingPoint].position;
        previousPosition = transform.position;
    }
    void FixedUpdate()
    {
        Vector2 positionBeforeMove = transform.position;

        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

        Vector2 movement = (Vector2)transform.position - positionBeforeMove;

        foreach (Rigidbody2D passenger in passengers)
        {
            passenger.position += movement;
        }
        previousPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null && rb.bodyType == RigidbodyType2D.Dynamic)
        {
            passengers.Add(rb);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null && passengers.Contains(rb))
        {
            passengers.Remove(rb);
        }
    }
}