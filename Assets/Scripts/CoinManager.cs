using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public TMP_Text coinText;
    public static CoinManager instance;

    void Update()
    {
        coinText.text = "Coins: " + ScoreSingleton.Instance.coinCount.ToString();
    }
    private void Awake()
    {
        instance = this;
    }
}