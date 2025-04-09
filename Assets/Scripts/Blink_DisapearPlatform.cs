using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink_DisapearPlatform : MonoBehaviour
{
    private float visibleTime = 3f;
    private float invisibleTime = 3f;
    private float initialDelay = 2f;


    public Collider2D platformCollider;
    public Collider2D platformCollider2;

    private SpriteRenderer platformRenderer;

    void Start()
    {
       
        platformRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(PlatformBlinkCycle());

    }

    private IEnumerator PlatformBlinkCycle()
    {
        if (initialDelay > 0)
        {
            yield return new WaitForSeconds(initialDelay);
        }

        while (true)
        {
            // Platform appears 
            platformRenderer.enabled = true;
            platformCollider.enabled = true;

            yield return new WaitForSeconds(visibleTime);

            // Platform disappears 
            platformRenderer.enabled = false;
            platformCollider.enabled = false;

            yield return new WaitForSeconds(invisibleTime);
        }
    }

}
