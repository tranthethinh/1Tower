using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 0.5f;

    [HideInInspector]
    public float speed;

    private float startHealth = 100;
    private float enemyHealth;

    public int worth = 50;

    //public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Slider healthBar;

    private bool isDead = false;
    TextUI textUI;// using for  damage popups

    
    public AudioClip deathSound;
    private AudioSource audioSource;

    public float GetHealth()
    {
        return enemyHealth;
    }
    void Start()
    {
        speed = startSpeed;
        enemyHealth = startHealth;
        textUI = GameObject.Find("GameManager").GetComponent<TextUI>();

        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float amount, bool _isCritical)
    {
        
        if (!_isCritical)
        {
            if (textUI != null)
            {
                textUI.ShowDamageText(this.gameObject, amount, _isCritical);
            }
            else
            {
                Debug.LogError("textUI is null in Enemy.TakeDamage");
            }

            enemyHealth -= amount;
        }
        else
        {
            enemyHealth -= amount*2;
            textUI.ShowDamageText(this.gameObject, amount*2,_isCritical);
        }
       

        healthBar.value = enemyHealth / startHealth;
        
        if (enemyHealth <= 0 && !isDead)
        {
            Die();
        }
    }
    

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

   

    void Die()
    {
        audioSource.PlayOneShot(deathSound);
        isDead = true;

        PlayerStats.coin += worth;
        Destroy(gameObject);
        //cai nay lam enemy ko xoa ngay nen de am thanh die o hieu ung die
        //StartCoroutine(DelayedDestroy());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead)
        {
            if (collision.CompareTag("Tower"))
            {
                Tower tower = collision.GetComponent<Tower>();
                tower.TakeDamage(enemyHealth);
                
                Destroy(gameObject);
            }
        }
    }
    
}
