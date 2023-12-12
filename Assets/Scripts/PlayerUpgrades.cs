using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerUpgrades
{
    public int upgradeCoin;
    public float currentValue;

    public PlayerUpgrades(int initialCoin, float initialValue)
    {
        upgradeCoin = initialCoin;
        currentValue = initialValue;
    }
}
