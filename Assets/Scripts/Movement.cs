using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    
    //Config Params
    [SerializeField] GameObject waypoints;
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float warpInSpeed = .5f;
    [SerializeField] bool hasWarped = false;
    [SerializeField] FlowController flowController;
    // State
    List<Transform> paths;
    bool hasReachedDestination = true;
    int destination = 0;


    void Start ()
    {
        
        paths = CreatePaths();
        transform.position = paths[0].transform.position;
        GetRandomDestination();
    }
  
    void Update ()
    {
        if (flowController.gameHasStarted == true)
        {
            Debug.Log("INHERE");
            if (!hasWarped)
            {
                WarpIn();
            }
            else
            {
                Move();
            }
        }
    }

    private List<Transform> CreatePaths()
    {

        var tempList = new List<Transform>();
        foreach (Transform thePath in waypoints.transform)
        {
            tempList.Add(thePath);
        }
        return tempList;

    }

    private void WarpIn()
    {

        var targetPosition = paths[1].transform.position;
        var movementThisFrame = warpInSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
        if (transform.position == targetPosition)
        {
            hasWarped = true;
            flowController.enemyWarpedIn = true;
        }

    }

    private void Move()
    {

        if (hasReachedDestination)
        {
            GetRandomDestination();
        }
        else
        {
            var targetPosition = paths[destination].transform.position;
            var movementThisFrame = movementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                hasReachedDestination = true;
            }
        }

    }

    private void GetRandomDestination()
    {

        destination = UnityEngine.Random.Range(1, paths.Count);
        hasReachedDestination = false;

    }

}
