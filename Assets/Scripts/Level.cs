using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    // Parameters
    [SerializeField] int breakableBlocks; //For debugging purposes

    // Cached references
    SceneLoader sceneLoader;


    public void Start()
    {

        sceneLoader = FindObjectOfType<SceneLoader>();

    }

	public void CountBreakableBlocks()
    {

            breakableBlocks++;

    }

    public void BlockDestroyed()
    {

        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }

    }

}
