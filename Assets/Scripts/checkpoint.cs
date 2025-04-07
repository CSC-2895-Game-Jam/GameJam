using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public int theCheckpoint = 0;

    public String platformColor;

    //Late Activation 
    public bool useDelayedActivation = false;

    private bool playerOnCheckpoint = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (useDelayedActivation) { 
            playerOnCheckpoint = true;
                StartCoroutine(delayedCheckpoint());
            }
            else
            {
                activateCheckpoint();
            }
        }

    }

    public Quaternion getNewPlayerRotation(){
        float rot = 0;
        string color = platformColor.ToLower();
        if(color == "blue") rot = 0;
        else if(color == "red") rot = -120;
        else if(color == "yellow") rot = 120;
        else {
            Debug.LogWarning("please set color for checkpoint to rotate player to.");
            return FindObjectOfType<playerController>().gameObject.transform.rotation;
        }

        return Quaternion.Euler(0, 0, rot);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerOnCheckpoint = false;
        }
    }

    private IEnumerator delayedCheckpoint()
    {
        yield return new WaitForSeconds(1.5f);
        if (playerOnCheckpoint)
        {
            activateCheckpoint();
        }
        else
        {
            Debug.Log("Player elft checkpoint before activation");
        }
    }


    private void activateCheckpoint()
    {
        gameController gc = FindObjectOfType<gameController>();
        if (gc != null)
        {
            gc.SetCheckpoint(gameObject, theCheckpoint);
            Debug.Log("Checkpoint Changed");
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                Color c = sr.color;
                c.a = 0f;
                sr.color = c;
            }

        }

        if (gc == null)
        {

            Debug.Log("gameController not found!");
        }
    }



}
