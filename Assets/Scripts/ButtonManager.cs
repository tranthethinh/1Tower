using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ButtonManager : MonoBehaviour
{
    
    public static int attackSpeedUpgradeCoin = 10;
    public static int damageUpgradeCoin = 10;
    public static int healthUpgradeCoin = 10;
    public static int rangeUpgradeCoin = 10;
    public static int criticalUpgradeCoin = 10;
    public static int gameSpeedUpgradeCoin = 10;
    public static int regenHealthUpgradeCoin = 10;
    public static int oneHitUpgradeCoin = 10;
    public static float currentMaxTimeScale = 1;

    private Tower tower;

    private float coinIncreaseMultiplier = 1.1f;

    private bool isPaused = false;
    public GameObject pauseUI;
    public GameObject buttonSpeedUI;


    public Button buttonAttackSpeed;
    public Button buttonRange;
    public Button buttonDamage;
    public Button buttonMaxHealth;
    public Button buttonCrit;
    public Button buttonGameSpeed;
    public Button buttonRegenHealth;
    public Button buttonOneHit;


    
    private void Start()
    {
        tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();

        //currentMaxTimeScale = Tower.gameSpeed;
    }

    private void Update()
    {
        SetColorAllButton();
    }
    void SetColorAllButton()
    {
        SetButtonColor(attackSpeedUpgradeCoin, buttonAttackSpeed);
        SetButtonColor(damageUpgradeCoin, buttonDamage);
        SetButtonColor(healthUpgradeCoin, buttonMaxHealth);
        SetButtonColor(rangeUpgradeCoin, buttonRange);
        SetButtonColor(criticalUpgradeCoin, buttonCrit);
        SetButtonColor(gameSpeedUpgradeCoin, buttonGameSpeed);
        SetButtonColor(regenHealthUpgradeCoin, buttonRegenHealth);
        SetButtonColor(oneHitUpgradeCoin, buttonOneHit);
}
    public void SetButtonColor(int coinNeedToUpgrade, Button button)
    {
        Color newColor;

       
        if (PlayerStats.coin > coinNeedToUpgrade && !isPaused)
        {
         
            newColor = Color.green;
            //Debug.Log("Button color set to green");
        }
        else
        {
            newColor = Color.gray;
            //Debug.Log("Button color set to gray");
        }

      
        Image buttonImage = button.GetComponent<Image>();

        
        if (buttonImage != null)
        {
          
            buttonImage.color = newColor;
        }
        else
        {
            Debug.LogError("ButtonAttackSpeed does not have an Image component.");
        }
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
        GameManager.canContinue = true;
        SaveSystem.Save();

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
        GameManager.canContinue = true;
        SaveSystem.Save();

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
   
    public void upgradeAttackSpeed ()
    {
        if (PlayerStats.coin > attackSpeedUpgradeCoin && !isPaused) 
        {
            PlayerStats.coin -= attackSpeedUpgradeCoin;
            tower.AddFireRate();
            attackSpeedUpgradeCoin = Mathf.RoundToInt(attackSpeedUpgradeCoin * 1.5f);
            
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
            rangeUpgradeCoin = Mathf.RoundToInt(rangeUpgradeCoin * 3);
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
    public void upgradeRegenHealth()
    {
        if (PlayerStats.coin > regenHealthUpgradeCoin && !isPaused)
        {
            PlayerStats.coin -= regenHealthUpgradeCoin;
            tower.AddRegenHealth();
            regenHealthUpgradeCoin = Mathf.RoundToInt(regenHealthUpgradeCoin * coinIncreaseMultiplier);
        }
        else
        {
            Debug.Log("Not enough money, Paused");
        }
    }
    public void upgradeOneHitPercentage()
    {
        if (PlayerStats.coin > oneHitUpgradeCoin && !isPaused)
        {
            PlayerStats.coin -= oneHitUpgradeCoin;
            tower.AddOneHitPercentage();
            oneHitUpgradeCoin = Mathf.RoundToInt(oneHitUpgradeCoin * 1.5f);
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
            currentMaxTimeScale += 0.5f;
            Time.timeScale = currentMaxTimeScale;
            gameSpeedUpgradeCoin = Mathf.RoundToInt(gameSpeedUpgradeCoin * 2);
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
            Time.timeScale += 0.5f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
   

    public int AttackSpeedUpgradeCoin
    {
        get { return attackSpeedUpgradeCoin; }
    }

    public int DamageUpgradeCoin
    {
        get { return damageUpgradeCoin; }
    }

    public int HealthUpgradeCoin
    {
        get { return healthUpgradeCoin; }
    }

    public int RangeUpgradeCoin
    {
        get { return rangeUpgradeCoin; }
    }

    public int CriticalUpgradeCoin
    {
        get { return criticalUpgradeCoin; }
    }

    public int GameSpeedUpgradeCoin
    {
        get { return gameSpeedUpgradeCoin; }
    }

    public int RegenHealthUpgradeCoin
    {
        get { return regenHealthUpgradeCoin; }
    }

    public int OneHitUpgradeCoin
    {
        get { return oneHitUpgradeCoin; }
    }
}
