using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        GetReady();
        Pause();
    }
    public void Play()
    {   
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        pipeRun[] pipes = FindObjectsOfType<pipeRun>();
        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GetReady()
    {
        gameOver.SetActive(false);
        playButton.SetActive(true);
        getReady.SetActive(true);
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void increaeseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
