using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{

    RectTransform canvas;
    RectTransform text;
    Vector3 startingPosition;

    public float speed;
    bool doNotRun = true;

    // TODO  Add an up or down option as well
    // TODO Make them move a bit off screen, then come back if needed.
    // TODO Make a comeback method
    public void MoveOffScreen()
    {
        text = gameObject.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        startingPosition = transform.position;
        doNotRun = false;
    }

    void Update()
    {
        if (!doNotRun)
        {
            transform.Translate(speed, 0f, 0f);
            if (text.position.y < -text.rect.height)
                transform.position = new Vector3(startingPosition.x, canvas.rect.height + text.rect.height, startingPosition.z);
        }
    }
}