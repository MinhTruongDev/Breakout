using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    int score;
    int highscore;


    private void Awake()
    {
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "Highscore: " + highscore.ToString();

    }

    public void GetPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void Restart()
    {
        Destroy(gameObject);
    }
}
