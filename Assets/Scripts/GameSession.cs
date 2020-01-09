﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // Config Params
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int PointsPerBlockDestroyed = 2;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // State Variables
    [SerializeField] int currentScore;


    private void Awake()
    {

        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start ()
    {

        scoreText.text = currentScore.ToString();

    }
	
	void Update ()
    {

        Time.timeScale = gameSpeed;	

	}

    public void AddToScore()
    {

        currentScore+= PointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();

    }

    public void Restart()
    {

        Destroy(gameObject);

    }

    public bool IsAutoPlayEnabled()
    {

        return isAutoPlayEnabled;

    }

}