using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioClip title;
    public AudioClip cybernoid1;
    public AudioSource myAudio;
    [SerializeField] FlowController flowController;
    //public AudioSource audio;
	// Use this for initialization
	void Start ()
    {
        // Gets the title clip playing and loops it until start is clicked
        myAudio.clip = title;
        myAudio.volume = .55f;
        myAudio.loop = true;
        myAudio.Play();
	}
	
	public void StartFirstWave()
    {
        // Start was clicked, do the proccess for starting the first wave music. (Was sent here from flow control)
        myAudio.loop = false;
        StartCoroutine(WaitForTitleLoopToEnd());
        
        
    }

    IEnumerator WaitForTitleLoopToEnd()
    {
        // Wait for title music to finish final loop
        yield return new WaitWhile(() => myAudio.isPlaying);
        // This extra .1 second is to make the switch to cybernoid1.mp3 seamless
        yield return new WaitForSeconds(.1f);
        myAudio.clip = cybernoid1;
        myAudio.volume = 1f;
        myAudio.Play();
        myAudio.loop = true;
        flowController.gameHasStarted = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
