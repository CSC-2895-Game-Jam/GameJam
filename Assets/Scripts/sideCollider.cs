using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class sideCollider : MonoBehaviour
{
    public String color;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != color && collision.gameObject.tag != "Platform" )
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
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
