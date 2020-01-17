using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseImageMove : MonoBehaviour {

    // Use this for initialization
    bool clickStart = false;

    public void BeginTransition()
    {
        clickStart = true;
        MoveAndDestroy();
        // StartCoroutine(MoveAndDestroy());
    }

    private void MoveAndDestroy()
    {
       // yield return new WaitForSeconds(5);
       // Destroy(gameObject);
    }

    void Update()
    {
      
        if (clickStart)
        {
          
            transform.Translate(0, -.2f, 0);
        }
    }
	
}
