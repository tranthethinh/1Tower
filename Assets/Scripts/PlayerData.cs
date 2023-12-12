using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool hasData;
    public int currentDay;
    public float range;
    public float fireRate;
    public int damage;
    public float maxHealth;
    public float health;
    public float critical;
    public int coin;
    public float gameSpeed;
    public float regenHealth;
    public float oneHitPercentage;

    public PlayerUpgrades attackSpeedUpgrade = new PlayerUpgrades(10, 1f);
    public PlayerUpgrades damageUpgrade = new PlayerUpgrades(10, 2f);
    public PlayerUpgrades healthUpgrade = new PlayerUpgrades(10, 10f);
    public PlayerUpgrades rangeUpgrade = new PlayerUpgrades(10, 10f);
    public PlayerUpgrades criticalUpgrade = new PlayerUpgrades(10, 0f);
    public PlayerUpgrades gameSpeedUpgrade = new PlayerUpgrades(10, 1f);
    public PlayerUpgrades regenHealthUpgrade = new PlayerUpgrades(10, 0f);
    public PlayerUpgrades oneHitUpgrade = new PlayerUpgrades(10, 0f);
    public PlayerData()
    {
        hasData = GameManager.canContinue;

        currentDay = CircleSpawner.currentDay;
        /*range = Tower.range;    
        fireRate = Tower.fireRate;  
        damage = Tower.damage;
        maxHealth = Tower.maxHealth;
        health = Tower.health;
        critical = Tower.critical;
        coin = PlayerStats.coin;
        gameSpeed = Tower.gameSpeed;
        regenHealth = Tower.regenHealth;
        oneHitPercentage = Tower.oneHitPersentage;*/
        rangeUpgrade.currentValue = Tower.range;
        attackSpeedUpgrade.currentValue = Tower.fireRate;
        damageUpgrade.currentValue = Tower.damage;
        healthUpgrade.currentValue = Tower.maxHealth;
        health = Tower.health;
        criticalUpgrade.currentValue = Tower.critical;
        coin = PlayerStats.coin;
        gameSpeedUpgrade.currentValue = ButtonManager.currentMaxTimeScale;
        regenHealthUpgrade.currentValue = Tower.regenHealth;
        oneHitUpgrade.currentValue = Tower.oneHitPersentage;

        rangeUpgrade.upgradeCoin = ButtonManager.rangeUpgradeCoin;
        attackSpeedUpgrade.upgradeCoin= ButtonManager.attackSpeedUpgradeCoin;
        damageUpgrade.upgradeCoin = ButtonManager.damageUpgradeCoin;
        healthUpgrade.upgradeCoin = ButtonManager.healthUpgradeCoin;
        criticalUpgrade.upgradeCoin = ButtonManager.criticalUpgradeCoin;
        gameSpeedUpgrade.upgradeCoin =ButtonManager.gameSpeedUpgradeCoin;
        regenHealthUpgrade.upgradeCoin=ButtonManager.regenHealthUpgradeCoin;
        oneHitUpgrade.upgradeCoin = ButtonManager.oneHitUpgradeCoin;
    }
}
