using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FlowController : MonoBehaviour {


    MusicPlayer musicPlayer;
    public bool gameHasStarted = false;
    public bool enemyWarpedIn = false;
	// Use this for initialization
	void Start ()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
       
	}

    public void StartWasClicked()
    {
        // Cues the music player that start was clicked and change the music to the first wave song.
        musicPlayer.StartFirstWave();
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.scoreText.enabled = true;
        MouseImageMove mouseImageMove = FindObjectOfType<MouseImageMove>();
        mouseImageMove.BeginTransition();
        
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
