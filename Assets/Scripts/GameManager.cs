using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public GameObject continueButton; 

    void Start()
    {
        // Check if there is saved data
        
        if (Tower.LoadTower())
        {
            Debug.Log("check to hide continue button1");
            continueButton.SetActive(true);
        }
        else
        {
            Debug.Log("check to hide continue button2");
            continueButton.SetActive(false);
        }
    }
    public void LoadTowerInNewScene()
    {
        //Tower.LoadTower(); the data automatic load in start()

    }
    public void ContinueGame()
    {
        
        LoadTowerInNewScene();
        SceneManager.LoadScene(1);
    }

    public void StartNewGame()
    {
        Tower.ResetGame();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // Quit the application (works in standalone builds)
        Application.Quit();
    }
    public static void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
