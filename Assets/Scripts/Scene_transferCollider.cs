using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_transferCollider : MonoBehaviour
{

    public int targetSceneIndex;

    public string ActivateTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ActivateTag))
        {
            SceneManager.LoadScene(targetSceneIndex);
        }
    }
    public void LoadMenu() {


        SceneManager.LoadScene("MainMenu");
    
    }
    

    


}
