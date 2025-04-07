using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool _collected = false;
    private int collection = 1;


    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
       if (_collected) { return;}

        if (other.CompareTag("Player"))
        {
            _collected = true;
            _collider.enabled = false; // stops more triggers
            Debug.Log("Collection2: " + collection);
            StartCoroutine(coinCollectionHandler());
        }
        
    }

    private IEnumerator coinCollectionHandler()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Collection: " + collection);
        CoinManager.instance.coinCount +=  collection;
        collection -= 1;
        Debug.Log("Collection2: " + collection);

        Destroy(gameObject);
    }
}