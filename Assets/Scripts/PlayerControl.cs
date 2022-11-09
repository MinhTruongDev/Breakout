using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{     
    private float xMax = 15f;   
    private float xMin = 0f;
    private float screenWidth_In_Unit = 15f;

    private void Update()
    {
        PaddleMovement();
    }

    private void PaddleMovement()
    {
        

        /*Prevent paddle move outside of the screen.
        Sources: https://answers.unity.com/questions/925199/restricting-movement-with-mathfclamp.html */

        Vector2 clampedPosition = new Vector2(transform.position.x, transform.position.y);
        clampedPosition.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = clampedPosition;
    }
   
    public float GetXPos()
    {
        return Input.mousePosition.x / Screen.width * screenWidth_In_Unit;
    }
}
