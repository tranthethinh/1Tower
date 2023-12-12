using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Tower : MonoBehaviour
{
    private GameObject target;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public static float range ;
    public static float fireRate;
    private float fireCooldown;
    public static float damage;
    public static float maxHealth;
    public static float health;
    public static float critical;
    //public static float gameSpeed;
    public static float regenHealth;
    public static float oneHitPersentage;


    
    public GameObject objectRange;
    private DetectEnemyInRange enemyDetector;
    List<GameObject> detectedEnemies;

    public AudioClip ShootSound;
    private AudioSource audioSource;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        //health = maxHealth;
        // Initialize the cooldown timer
        fireCooldown = 0f;

        // Start the coroutine for health regeneration
        StartCoroutine(RegenerateHealth());

        enemyDetector = GetComponentInChildren<DetectEnemyInRange>();

    }

    void Update()
    {
        UpdateTarget();

        // Check if it's time to shoot
        if (fireCooldown <= 0f && target != null)
        {
            Shoot();

            if (target.GetComponent<Enemy>().GetHealth() < damage)  //check if enemy die in this shoot
            {
                detectedEnemies.Remove(target);//remove from list enemies
                target = null;

            }
            fireCooldown = 1f / fireRate; // Reset the cooldown timer
        }

        // Decrease the cooldown timer
        fireCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        PlayShootSound();
        if (bullet != null)
            bullet.Seek(target.transform);
    }
    private void PlayShootSound()
    {
        // Check if the AudioSource is not null before playing the sound
        if (ShootSound != null)
        {
            audioSource.PlayOneShot(ShootSound);
        }
    }
    void UpdateTarget()
    {
        /*GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)*/
        detectedEnemies = enemyDetector.detectedEnemies;
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in detectedEnemies)
        {
            if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }

        //if (nearestEnemy != null && shortestDistance <= range)
        if (nearestEnemy != null)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;



        if (health <= 0)
        {
            health = 0;
            Debug.Log("GameOver");
            GameOverManager.instance.gameIsOver = true;
            GameOverManager.instance.GameOver();
            GameManager.canContinue = false;
            SaveSystem.Save();
        }
    }
    public void AddFireRate()
    {
        fireRate += 0.1f;
    }
   

    public void AddRange()
    {
        objectRange.transform.localScale *= 1.1f;
        range *= 1.1f;
        
    }
    
    public void AddMaxHealth()
    {
        maxHealth *= 1.1f;
        health *= 1.1f;
    }
    public void AddDamage()
    {
        damage += 1;
    }
    public void AddCrit()
    {
        critical += 0.1f;
    }
    public void AddRegenHealth()
    {
        regenHealth += 0.1f;
    }
    IEnumerator RegenerateHealth()
    {
        while (true)
        {
            if (health < maxHealth)
            {
                health += regenHealth;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
                yield return new WaitForSeconds(1);
            }
            else
            {
                health = maxHealth;
                yield return null;
            }
        }
    }
    public void AddOneHitPercentage()
    {
        oneHitPersentage += 0.1f;
    }

   

}
