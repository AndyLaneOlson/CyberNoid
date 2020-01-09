using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    //Configuration Parameters
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileFireTime = 3.0f;
    [SerializeField] float minShootAngle = 150f;
    [SerializeField] float maxShootAngle = 210f;

    // State
    float randomRotation;

	
    // Use this for initialization
	void Start ()
    {

        StartCoroutine(StartingWaitTime());
     
    }
	
    IEnumerator StartingWaitTime()
    {
        Debug.Log("Here");
        yield return new WaitForSeconds(7f);
        Debug.Log("Here2");
        StartCoroutine(Fire());

    }

	// Update is called once per frame
	void Update ()
    {
       
    }

    IEnumerator Fire()
    {
       
        {
            Vector3 adjustedPosition = new Vector3(transform.position.x, transform.position.y - 1.4f, transform.position.z);
            randomRotation = UnityEngine.Random.Range(minShootAngle, maxShootAngle);
            GameObject laser = Instantiate(laserPrefab, adjustedPosition, Quaternion.Euler(0f, 0f, randomRotation));
            laser.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up, ForceMode2D.Impulse);
            yield return new WaitForSeconds(projectileFireTime);
            StartCoroutine(Fire());
        }
       
    }

}
