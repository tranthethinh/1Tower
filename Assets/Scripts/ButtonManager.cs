using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    
    private int attackSpeedUpgradeCoin = 10;
    private int damageUpgradeCoin = 10;
    private int healthUpgradeCoin = 10;
    private int rangeUpgradeCoin = 10;
    private int criticalUpgradeCoin = 10;
    private int gameSpeedUpgradeCoin = 10;

    public static float currentMaxTimeScale = 1;

    private Tower tower;

    private float coinIncreaseMultiplier = 1.1f;

    private bool isPaused = false;
    public GameObject pauseUI;
    public GameObject buttonSpeedUI;
    private void Start()
    {
        tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();

        currentMaxTimeScale = Tower.gameSpeed;
    }
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        buttonSpeedUI.SetActive(false);
        Tower.canContinue = true;
        tower.saveTower();

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        buttonSpeedUI.SetActive(true);
        isPaused = false;
    }
    public void Exit()
    {
        Tower.canContinue = true;
        tower.saveTower();

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
   
    public void upgradeAttackSpeed ()
    {
        if (PlayerStats.coin > attackSpeedUpgradeCoin && !isPaused) 
        {
            PlayerStats.coin -= attackSpeedUpgradeCoin;
            tower.AddFireRate();
            attackSpeedUpgradeCoin = Mathf.RoundToInt(attackSpeedUpgradeCoin * coinIncreaseMultiplier);
        }
        else
        {
            Debug.Log("Not enough money, Paused");
        }
    }
    public void upgradeDamage()
    {
        if (PlayerStats.coin > damageUpgradeCoin && !isPaused)
        {
            PlayerStats.coin -= damageUpgradeCoin;
            tower.AddDamage();
            damageUpgradeCoin = Mathf.RoundToInt(damageUpgradeCoin * coinIncreaseMultiplier);
        }
        else
        {
            Debug.Log("Not enough money, Paused");
        }
    }
    public void upgradeHealth()
    {
        if (PlayerStats.coin > healthUpgradeCoin && !isPaused)
        {
            PlayerStats.coin -= healthUpgradeCoin;
            tower.AddMaxHealth();
            healthUpgradeCoin = Mathf.RoundToInt(healthUpgradeCoin * coinIncreaseMultiplier);
        }
        else
        {
            Debug.Log("Not enough money, Paused");
        }
    }
    public void upgradeRange()
    {
        if (PlayerStats.coin > rangeUpgradeCoin && !isPaused)
        {
            PlayerStats.coin -= rangeUpgradeCoin;
            tower.AddRange();
            rangeUpgradeCoin = Mathf.RoundToInt(rangeUpgradeCoin * coinIncreaseMultiplier);
        }
        else
        {
            Debug.Log("Not enough money, Paused");
        }
    }
    public void upgradeCrit()
    {
        if (PlayerStats.coin > criticalUpgradeCoin && !isPaused)
        {
            PlayerStats.coin -= criticalUpgradeCoin;
            tower.AddCrit();
            criticalUpgradeCoin = Mathf.RoundToInt(criticalUpgradeCoin * coinIncreaseMultiplier);
        }
        else
        {
            Debug.Log("Not enough money, Paused");
        }
    }
    public void upgradeGameSpeed()
    {
        if (PlayerStats.coin > gameSpeedUpgradeCoin && !isPaused)
        {
            PlayerStats.coin -= gameSpeedUpgradeCoin;
            currentMaxTimeScale += 0.1f;
            gameSpeedUpgradeCoin = Mathf.RoundToInt(gameSpeedUpgradeCoin * coinIncreaseMultiplier);
        }
        else
        {
            Debug.Log("Not enough money, Paused");
        }
    }
    public void ChangeGameSpeed()
    {
        if( Time.timeScale < currentMaxTimeScale && !isPaused)
        {
            Time.timeScale += 0.1f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
