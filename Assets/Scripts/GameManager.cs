using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int level = 1;


    private void Awake()
    {
        if(FindObjectsOfType<GameManager>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        
       
    }

    

    public void Restart()
    {
        Destroy(gameObject);
    }
}
