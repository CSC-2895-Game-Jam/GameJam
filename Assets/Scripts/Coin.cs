using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool _collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!_collected && other.CompareTag("Player"))
        {
            _collected = true;
            CoinManager.instance.coinCount++;
            StartCoroutine(DestroyAfterFrame());
        }
    }

    private IEnumerator DestroyAfterFrame()
    {
        Debug.Log("Coin destroyed next frame.");
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}