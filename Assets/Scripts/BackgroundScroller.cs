using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 1;
    public float backgroundLength = 20.48f;

    void FixedUpdate()
    {
        transform.Translate(-scrollSpeed * Time.deltaTime,0,0);
        if (transform.position.x < -backgroundLength)
        {
            transform.position = (Vector2)transform.position + new Vector2(backgroundLength, 0);
        }
    }
}
