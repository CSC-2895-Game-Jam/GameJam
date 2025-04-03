using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class sideCollider : MonoBehaviour
{
    public String color;
    private playerController player;

    void Start()
    {
        player = gameObject.transform.parent.GetComponent<playerController>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != color && collision.gameObject.tag != "Platform")
        {
            // Player falls through
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            player.setAllowJump(false);

        }
        if ((collision.gameObject.tag == color || collision.gameObject.tag == "Platform") && transform.up.y < 0)
        {

            player.setAllowJump(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == color || collision.gameObject.tag == "Platform")
        {
            player.setAllowJump(false);
        }
    }

}
