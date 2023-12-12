using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private float startSpeed = 0.5f;

    
    public float speed;

    protected float startHealth = 5;
    protected float enemyHealth;

    protected int worth = 5;

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
    protected void Start()
    {
        speed = startSpeed;
        enemyHealth = startHealth*(CircleSpawner.currentDay/10+1);//increase each 10 days
        worth *= (CircleSpawner.currentDay / 10+1);


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

   

    public void Die()
    {
        audioSource.PlayOneShot(deathSound);
        isDead = true;

        PlayerStats.coin += worth;
        Destroy(gameObject);
       
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
