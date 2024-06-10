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

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    //Restart Game
    public void restartGame()
    {
        Debug.Log("click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        resumeGame();
    }

    //Game Over
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        pauseGame();
    }

    //Pause and Continue

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
    }
}
