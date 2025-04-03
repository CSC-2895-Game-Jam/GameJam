using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class sideCollider : MonoBehaviour
{
    public String color;
    private gameController gc;

    void Start()
    {
         gc = FindObjectOfType<gameController>();
        
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != color && collision.gameObject.tag != "Platform" )
        {
            //Player falls through
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());


            //Teleport player back to last checkpoint
            if (gc != null)
            {
                gc.telportToLastCheckpoint();
                Debug.Log("teleporting...!");
            }
            else
            {
                Debug.Log("gc not found!");
            }


        } else {
            gameObject.transform.parent.GetComponent<playerController>().setGrounded(true);


        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == color || collision.gameObject.tag == "Platform" ){
            gameObject.transform.parent.GetComponent<playerController>().setGrounded(false);


        }
    }

}
