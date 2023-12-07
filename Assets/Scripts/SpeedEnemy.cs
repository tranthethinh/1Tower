using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedEnemy : Enemy
{
    
    public float speedMultiplier = 1.5f;

    protected new void Start()
    {
        
        base.Start();

        
        speed *= speedMultiplier;
    }

    
}
