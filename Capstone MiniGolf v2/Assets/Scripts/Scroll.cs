using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private float width = 128f;
    private void Start()
    {
        
    }

    private void Update()
    {
        Vector2 vector = new Vector2(-width * Time.deltaTime, 0);
        transform.position = (Vector2)transform.position + vector;
        if (transform.position.x < -1125)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        transform.position = (Vector2)transform.position + new Vector2(2250, 0);
    }
}
