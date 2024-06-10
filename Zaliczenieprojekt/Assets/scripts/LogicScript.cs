using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public GameObject PauseMenuScreen;

    public bool isPaused;
    public bool isGameOver;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    //Restart Game
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    //Game Over
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        isGameOver = true;
    }

    //Game Menu
    public void gameMenu()
    {
        if (isPaused)
        {
            resumeGame();
        }
        else
        {
            pauseGame();
        }
    }

    //Pause and Continue

    public void pauseGame()
    {
        PauseMenuScreen.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void resumeGame()
    {
        PauseMenuScreen.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
