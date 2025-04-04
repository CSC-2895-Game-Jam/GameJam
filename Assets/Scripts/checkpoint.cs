using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public int theCheckpoint = 0;

    public String platformColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameController gc = FindObjectOfType<gameController>();
            if (gc != null)
            {
                gc.SetCheckpoint(gameObject, theCheckpoint);
                Debug.Log("Checkpoint Changed");
            }

            if (gc == null)
            {

                Debug.Log("gameController not found!");
            }
        }
        else {
            Debug.Log("player tag not found!");
        }

    }

    public Quaternion getNewPlayerRotation(){
        float rot = 0;

        if(platformColor == "Blue") rot = 0;
        else if(platformColor == "Red") rot = -120;
        else if(platformColor == "Yellow") rot = 120;
        else Debug.LogWarning("please set color for checkpoint to rotate player to.");

        return Quaternion.Euler(0, 0, rot);
    }
}
