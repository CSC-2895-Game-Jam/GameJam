using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//disappearing platform with fade effect, but player can still use the platform. 
public class Disappearing_Platform : MonoBehaviour
{

    private float VisibleTime = 2f;

    private float InvisibleTime = 2f;
    private float InitialDelay = 2f;

    private bool IsFading = true;
    private float FadeDuration = 4.0f;

    public Collider2D platformCollider;

    public Collider2D platformCollider2;

    private SpriteRenderer platformRenderer;

    private bool IsActive = true;

   

    void Start()
    {
        
        
    platformRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(PlatformCycle());
    }

    private IEnumerator PlatformCycle()
    {
        if (InitialDelay > 0)
        {
            yield return new WaitForSeconds(InitialDelay);
        }

        while (true)
        {
            IsActive = true;
           

            if (IsFading)
            {
                yield return StartCoroutine(FadeIn());
            }
            else
            {
                platformRenderer.enabled = true;
            }
            yield return new WaitForSeconds(VisibleTime);

            IsActive = false;

            if (IsFading)
            {
                yield return StartCoroutine(FadeOut());
            }
            else
            {
                platformRenderer.enabled = false;
            }
            

       

            // pause corotine execution 
            yield return new WaitForSeconds(InvisibleTime);
        }
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;

        Color startColor = platformRenderer.color;

        platformRenderer.enabled = true;

        while(timer < FadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / FadeDuration);

            platformRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            //pause corutine until next frame
            yield return null;
        }

        platformRenderer.enabled = false;
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color startColor = platformRenderer.color;

        while(timer < FadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / FadeDuration);

            platformRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            yield return null;
        }

        platformRenderer.enabled = false;
    }





}
