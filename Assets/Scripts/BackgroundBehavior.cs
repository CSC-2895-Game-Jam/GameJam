using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BackgroundSouce
{
    Origin,
    Right,
    Left
}

public class BackgroundBehavior : MonoBehaviour
{
    private GameObject player;
    public GameObject BGprefab;
    public BackgroundSouce source;
    private bool generated = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (source == BackgroundSouce.Origin)
        {
            GenerateLeft();
            GenerateRight();
        }
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            if (generated) return;
            if (source == BackgroundSouce.Right)
            {
                GenerateRight();
            }

            if (source == BackgroundSouce.Left)
            {
                GenerateLeft();
            }
        }
    }

    private void GenerateLeft()
    {
        if (generated) return;
        Debug.Log("Left BG generated!");
        GameObject next = Instantiate(BGprefab, this.transform.parent);
        next.transform.position = new Vector3(this.transform.position.x - 19.2f, player.transform.position.y, this.transform.position.z);
        next.GetComponent<BackgroundBehavior>().source = BackgroundSouce.Left;
    }

    private void GenerateRight()
    {
        if (generated) return;
        Debug.Log("Right BG generated!");
        GameObject next = Instantiate(BGprefab, this.transform.parent);
        next.transform.position = new Vector3(this.transform.position.x + 19.2f, player.transform.position.y, this.transform.position.z);
        next.GetComponent<BackgroundBehavior>().source = BackgroundSouce.Right;
    }
}
