using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseImageMove : MonoBehaviour {

    // Use this for initialization
    bool clickStart = false;

    public void BeginTransition()
    {
        clickStart = true;
        StartCoroutine(MoveAndDestroy());
    }

    IEnumerator MoveAndDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    void Update()
    {
        Debug.Log("First");
        if (clickStart)
        {
            Debug.Log("Second");
            transform.Translate(0, -.2f, 0);
        }
    }
	
}
