using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public string playerTag = "Player";
    public string spawnTag = "Spawn";
    private Transform playerTransform;
    private Transform checkpointTransform;
    private GameObject checkpoint;
    private GameObject player;

    public int currentCheckpoint = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        playerTransform = player.transform;
        checkpoint = GameObject.FindGameObjectWithTag(spawnTag);
        checkpointTransform = checkpoint.transform;
    }

    void Update()
    {
        if (playerTransform == null)
        {
            player = GameObject.FindGameObjectWithTag(playerTag);
            playerTransform = player.transform;
        }

        if (checkpointTransform == null)
        {
            checkpoint = GameObject.FindGameObjectWithTag(spawnTag);
            checkpointTransform = checkpoint.transform;
        }

    }

    public void SetCheckpoint(GameObject cp, int checkpointID)
    {
        checkpoint = cp;
        checkpointTransform = cp.transform;
        currentCheckpoint = checkpointID;
        Debug.Log("Checkpoint updated to ID: " + currentCheckpoint);
    }


    public void telportToLastCheckpoint()
    {

        if (playerTransform != null && checkpointTransform != null)
        {
            playerTransform.position = checkpointTransform.position;
            Debug.Log("Trying to teleport");

        }
        if (playerTransform == null)
        {
            Debug.Log("Player not found!");

        }
        if (checkpointTransform == null)
        {
            Debug.Log("Checkpoint not found!");

        }


    }
}