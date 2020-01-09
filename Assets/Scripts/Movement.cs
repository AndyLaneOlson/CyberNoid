using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //Config Params
    [SerializeField] GameObject waypoints;
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float warpInSpeed = .5f;

    // State
    List<Transform> paths;
    bool hasWarped = false;
    bool hasReachedDestination = true;
    int destination = 0;


    void Start ()
    {

        paths = CreatePaths();
        GetRandomDestination();
        transform.position = paths[0].transform.position;
        
	}
  
    void Update ()
    {

        if (!hasWarped)
        {
            WarpIn();
        }
        else
        {
            Move();
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

        destination = UnityEngine.Random.Range(1, paths.Count - 1);
        hasReachedDestination = false;

    }

}
