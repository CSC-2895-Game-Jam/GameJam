using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public string playerTag = "Player";
    public string spawnTag = "Spawn";
    private Transform playerTransform;
    private Transform checkpointTransform;
    private GameObject checkpoint;
    private GameObject player;
    private Rigidbody2D playerRB;

    public int currentCheckpoint = 0;

    public TextMeshProUGUI fallsText;

    private bool isTeleporting = false; // make sure only one teleportation method call


    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        playerTransform = player.transform;
        playerRB = player.GetComponent<Rigidbody2D>();
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
       if (isTeleporting) {
           return; //Ignore if teleporting
       }

        isTeleporting = true;

        if (playerTransform != null && checkpointTransform != null)
        {
            playerTransform.position = checkpointTransform.position;
            playerTransform.rotation = checkpoint.GetComponent<checkpoint>().getNewPlayerRotation();
            playerRB.velocity = Vector2.zero;
            Debug.Log("Trying to teleport");

            //Increment fall counter and update GUI
            ScoreSingleton.Instance.fallCount++;
            UpdateFallsText();

            StartCoroutine(resetTeleporting());

        }
        if (playerTransform == null)
        {
            Debug.Log("PlayerTransform not found!");

        }
        if (checkpointTransform == null)
        {
            Debug.Log("CheckpointTransform not found!");

        }
    }


    private IEnumerator resetTeleporting()
    {
        yield return new WaitForSeconds(0.2f);
        isTeleporting = false;
    }


    private void UpdateFallsText()
    {
        fallsText.text = "Fails: " + ScoreSingleton.Instance.fallCount.ToString("000");
    }

}