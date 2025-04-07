using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;
    public static CoinManager instance;

    void Update()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
    private void Awake()
    {
        instance = this;
    }
}