﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Paddle")
        {
            SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
            sceneLoader.LoadStartScene();
        }
        Destroy(gameObject);
    }
 
}
