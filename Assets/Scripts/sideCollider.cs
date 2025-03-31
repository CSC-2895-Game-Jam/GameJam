using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideCollider : MonoBehaviour
{
    public String tag;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != tag && collision.gameObject.tag != "Platform" )
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }

}
