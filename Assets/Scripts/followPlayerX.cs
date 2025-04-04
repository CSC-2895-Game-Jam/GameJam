using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerX : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
