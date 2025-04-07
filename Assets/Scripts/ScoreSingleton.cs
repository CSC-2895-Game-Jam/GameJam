using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSingleton : MonoBehaviour
{
    public static ScoreSingleton Instance;
    public int coinCount;
    public int fallCount;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
