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
    public PlayerData(Tower tower)
    {
        hasData = Tower.canContinue;

        currentDay = CircleSpawner.currentDay;
        range = Tower.range;    
        fireRate = Tower.fireRate;  
        damage = Tower.damage;
        maxHealth = Tower.maxHealth;
        health = Tower.health;
        critical = Tower.critical;
        coin = PlayerStats.coin;
        gameSpeed = Tower.gameSpeed;
    }
}
