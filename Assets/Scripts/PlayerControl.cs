using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 15f;   
    private float xMax = 7.71f;   
    private float xMin = -7.71f;   
    private void Update()
    {
        PaddleMovement();
    }

    private void PaddleMovement()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(xMove, 0, 0);

        /*Prevent paddle move outside of the screen.
        Sources: https://answers.unity.com/questions/925199/restricting-movement-with-mathfclamp.html */

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, xMin, xMax);
        transform.position = clampedPosition;
    }
   

}
