using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] private int hitPoint = 2;


    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Hit();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hit();
    }


    private void Hit()
    {
        
        hitPoint--;
        switch (hitPoint)
        {
            case 1:
                {
                    spriteRenderer.sprite = sprites[1];
                    break;
                }
            case 0:
                {
                    Destroy(gameObject);
                    break;
                }

        }
    }
}
