using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy_verticalMovement : MonoBehaviour
{

    public float speed = 3f;
    public float minValue = 12f;
    public float maxValue = 15f;
    private bool movingDown = true;
    private bool isPaused = false;
    public float randomFloat;

    private Rigidbody2D rb;

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        randomFloat = Random.Range(minValue, maxValue);
        Vector2 movement;
        if (!isPaused)
        {
            if (movingDown)
            {
                movement = Vector2.down;
                transform.Translate(movement * randomFloat * Time.deltaTime);
            }
            else
            {
                movement = Vector2.up;
                transform.Translate(movement * speed * Time.deltaTime);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
        
    {

        Debug.Log("Collision detacted");



        if (!isPaused)
        {
            StartCoroutine(PauseAndReverse());
        }
    }
    IEnumerator PauseAndReverse()
    {
        isPaused = true;

        yield return new WaitForSeconds(1f);


        movingDown = !movingDown;

        // resume movement after 2 second pause
        isPaused = false;
    }




}
