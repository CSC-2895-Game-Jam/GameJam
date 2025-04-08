using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuHandler : MonoBehaviour
{
    public AudioSource source;

 private IEnumerator WaitForSoundAndTransition(string sceneName){

            source.Play();
            yield return new WaitForSeconds(source.clip.length);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void goToGame2(){
        StartCoroutine(WaitForSoundAndTransition("Framework"));
    }


    public void goToMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
    public void goToGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("KateScene");
    }


public void endGame(){
    Application.Quit();


}


public void resetGameScene(){
    UnityEngine.SceneManagement.SceneManager.LoadScene( SceneManager.GetActiveScene().name );
}
    

}
