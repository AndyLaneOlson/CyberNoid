using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //AudioSource myAudio;

    //public void Start()
    //{
    //   // myAudio = FindObjectOfType<AudioSource>();
    //}

    //IEnumerator CheckIfReadyToLoad()
    //{
    //    myAudio.loop = false;
    //    yield return new WaitWhile(() => myAudio.isPlaying);
    //    SceneManager.LoadScene(1);  //!!!!!!!**** Must put this here, the main thread keeps running while yield is going on.
    //}

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //if (currentSceneIndex == 0)
        //{
        //    StartCoroutine(CheckIfReadyToLoad());
        //}
        //else
        //{
        //    SceneManager.LoadScene(currentSceneIndex + 1);
        //}
    }

    //public void LoadStartScene()
    //{

    //    SceneManager.LoadScene(0);
    //    FindObjectOfType<GameSession>().Restart();

    //}

    //public void Quit()
    //{

    //    Application.Quit();

    // }

}
