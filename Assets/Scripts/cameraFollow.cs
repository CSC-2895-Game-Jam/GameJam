using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    public string playerTag = "Player";
   // private Transform playerTransform;



    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag(playerTag);
       // playerTransform = player.transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            camera.transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }

    }
}
