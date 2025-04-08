using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class pause_button : MonoBehaviour
{
   

  public void MuteALL()
    {
        AudioSource[] allAudio = FindObjectsOfType<AudioSource>();

        foreach( AudioSource audiosource in allAudio)
        {
            audiosource.mute = true; 
        }
    }

    public void UnMuteALL()
    {
        AudioSource[] allAudio = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audiosource in allAudio)
        {
            audiosource.mute = false;
        }
    }
}


