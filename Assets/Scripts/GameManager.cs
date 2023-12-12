using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{

    public static bool canContinue = false;

    public GameObject continueButton;

    
    void Start()
    {
        // Check if there is saved data
        
        if (LoadData())
        {
            //Debug.Log("check to hide continue button1");
            continueButton.SetActive(true);
        }
        else
        {
            //Debug.Log("check to hide continue button2");
            continueButton.SetActive(false);
        }
    }
    public void LoadTowerInNewScene()
    {
        // the data automatic load in start()

    }
    public void ContinueGame()
    {
        
        LoadTowerInNewScene();
        SceneManager.LoadScene(1);
    }

    public void StartNewGame()
    {
        GameManager.ResetGame();
        canContinue= true;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        
        Application.Quit();
    }
    public static void Exit()
    {
        SceneManager.LoadScene(0);
    }
    

    public static bool LoadData()
    {
        PlayerData data = SaveSystem.Load();

        CircleSpawner.currentDay = data.currentDay;
        Tower.range = data.rangeUpgrade.currentValue;
        Tower.fireRate = data.attackSpeedUpgrade.currentValue;
        Tower.damage = data.damageUpgrade.currentValue;
        Tower.maxHealth = data.healthUpgrade.currentValue;
        Tower.health = data.health;
        Tower.critical = data.criticalUpgrade.currentValue;
        PlayerStats.coin = data.coin;
        Tower.regenHealth = data.regenHealthUpgrade.currentValue;
        Tower.oneHitPersentage = data.oneHitUpgrade.currentValue;

        ButtonManager.rangeUpgradeCoin = data.rangeUpgrade.upgradeCoin;
        ButtonManager.attackSpeedUpgradeCoin = data.attackSpeedUpgrade.upgradeCoin;
        ButtonManager.damageUpgradeCoin = data.damageUpgrade.upgradeCoin;
        ButtonManager.healthUpgradeCoin = data.healthUpgrade.upgradeCoin;
        ButtonManager.criticalUpgradeCoin = data.criticalUpgrade.upgradeCoin;
        ButtonManager.gameSpeedUpgradeCoin = data.gameSpeedUpgrade.upgradeCoin;
        ButtonManager.regenHealthUpgradeCoin = data.regenHealthUpgrade.upgradeCoin;
        ButtonManager.oneHitUpgradeCoin = data.oneHitUpgrade.upgradeCoin;
        ButtonManager.currentMaxTimeScale = data.gameSpeedUpgrade.currentValue;

        return data.hasData;
    }

    public static void ResetGame()
    {
        // Reset variables to their initial values
        Tower.range = 10f;
        Tower.fireRate = 1f;
        Tower.damage = 2;
        Tower.maxHealth = 10;
        Tower.health = Tower.maxHealth; // Reset health to maxHealth
        Tower.critical = 0.0f;
        //Tower.gameSpeed = 1.0f;
        CircleSpawner.currentDay = 1;
        PlayerStats.coin = 100;
        Tower.regenHealth = 0.0f;
        Tower.oneHitPersentage = 0.0f;

        ButtonManager.rangeUpgradeCoin = 10;
        ButtonManager.attackSpeedUpgradeCoin = 10;
        ButtonManager.damageUpgradeCoin = 10;
        ButtonManager.healthUpgradeCoin = 10;
        ButtonManager.criticalUpgradeCoin = 10;
        ButtonManager.gameSpeedUpgradeCoin = 10;
        ButtonManager.regenHealthUpgradeCoin = 10;
        ButtonManager.oneHitUpgradeCoin = 10;
        ButtonManager.currentMaxTimeScale = 1;
    }
}
