using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    private float bossSpeedMultiplier = 0.5f;
    private int bossWorthMultiplier = 10;
    private float bossHealthMultiplier = 10f;

    
    protected new void Start()
    {
       
        base.Start();

        
        speed *= bossSpeedMultiplier;
        worth *= bossWorthMultiplier;
        startHealth *= bossHealthMultiplier;
        enemyHealth = startHealth;
    }

    
}
