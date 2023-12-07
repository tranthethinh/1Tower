using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarUI : MonoBehaviour
{

    private Tower tower;

    public Slider healthBar;

    void Start()
    {
        tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();
    }

    
    void LateUpdate()
    {
        healthBar.value = Tower.health / Tower.maxHealth;
    }
}
