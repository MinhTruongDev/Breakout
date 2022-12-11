using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] private int hitPoint = 2;
    GameObject gameController;
    GameManager gameManager;
    int currentSprite = 0;


    SpriteRenderer spriteRenderer;
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[currentSprite];
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = FindObjectOfType<GameManager>();
        if (tag == "Breakable")
        {
            gameManager.CountBlock();
        }

    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameController.GetComponent<GameManager>().GetPoint();
        Hit();   
        
    }



    private void Hit()
    {
        
        hitPoint--;       
        switch (hitPoint)
        {
            case 1:
                {
                    spriteRenderer.sprite = sprites[currentSprite+1];
                    break;
                }
            case 0:
                {
                    Destroy(gameObject);
                    gameManager.BlockDestroyed();
                    break;
                }

        }
    }
}
