using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    // Configuration Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minXClamp;
    [SerializeField] float maxXClamp;

    // Cached References
    GameSession gameSession;
    Ball ball;


	void Start ()
    {

        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();

	}
	
	void Update ()
    {

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minXClamp, maxXClamp);
        transform.position = paddlePos;
		
	}

    private float GetXPos()
    {

        if(gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

}
