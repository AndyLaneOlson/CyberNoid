using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Ball")
        {
            SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
            sceneLoader.LoadStartScene();
        } 
        else
        {
            Destroy(collision.gameObject);
        }

    }
    
}
