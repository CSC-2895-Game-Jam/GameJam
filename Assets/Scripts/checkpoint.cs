using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public int theCheckpoint = 0;

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
}
