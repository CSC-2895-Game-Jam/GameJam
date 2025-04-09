using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
//using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
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
        if (collision.gameObject.CompareTag(color) || collision.gameObject.CompareTag("Platform"))
        {
            if(player.getCurrentSide() != color && !collision.gameObject.CompareTag("Platform")) {
                player.setAllowJump(false);
                return;
            };
            player.setAllowJump(true);
        }

        if (!collision.gameObject.CompareTag(color) && !collision.gameObject.CompareTag("Platform") && !collision.gameObject.CompareTag("Wall"))
        {
            // Player falls through
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            player.setAllowJump(false);
        }
    }
}
