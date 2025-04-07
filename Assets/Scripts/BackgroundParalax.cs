using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour
{

    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x * .75f, transform.position.y, transform.position.z);
    }
}
