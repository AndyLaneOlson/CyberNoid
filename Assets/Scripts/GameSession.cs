using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // Config Params
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // State Variables
    [SerializeField] float currentScore;
    public bool addToScore = false;

    private void Awake()
    {
        Time.timeScale = gameSpeed;
        scoreText.enabled = false;
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
        if (addToScore)
        {
            currentScore += Time.deltaTime;
            scoreText.text = Mathf.Round(currentScore).ToString();
           	
        }
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
