using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public TMP_Text coinText;

    void Update()
    {
        if(coinText == null) return;
        coinText.text = "Coins: " + ScoreSingleton.Instance.coinCount.ToString();
    }
}