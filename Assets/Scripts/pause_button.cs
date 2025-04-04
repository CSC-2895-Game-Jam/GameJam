using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class pause_button : MonoBehaviour
{
    public Sprite normalSprite;  
    public Sprite clickedSprite;  
    private Image buttonImage;     

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = normalSprite;
    }

    public void OnButtonClick()
    {
        // Change sprite when clicked
        buttonImage.sprite = clickedSprite;

        
    }

  
}


