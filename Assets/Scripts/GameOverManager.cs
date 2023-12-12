using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject gameOverUI;
    public GameObject playButtonUI;

    public bool gameIsOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GameOver()
    {
        gameIsOver = true;
        

        gameOverUI.SetActive(true);
        playButtonUI.SetActive(false);
        Time.timeScale = 0f; // This line pauses the game. Set it to 1f to resume.
    }

    public void RestartGame()
    {
        
        Time.timeScale = 1f; // Resume the game.
        GameManager.ResetGame();
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        GameManager.ResetGame();
        Time.timeScale = 1f; // Resume the game.
        SceneManager.LoadScene(0);
    }
}
