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
    public static float range = 10f;
    public static float fireRate = 1f;
    private float fireCooldown = 0f;
    public static int damage = 50;
    public static float maxHealth = 100;
    public static float health;
    public static float critical = 0;
    public static float gameSpeed = 1;
    public static bool canContinue = true;
    public GameObject objectRange;
    private DetectEnemyInRange enemyDetector;
    List<GameObject> detectedEnemies;

    public AudioClip ShootSound;
    private AudioSource audioSource;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
        // Initialize the cooldown timer
        fireCooldown = 0f;
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
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
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
            canContinue = false;
            saveTower();
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
        damage += 10;
    }
    public void AddCrit()
    {
        critical += 0.1f;
    }
    
    public void saveTower()
    {
        SaveSystem.Save(this);
    }
    public static bool LoadTower()
    {
        PlayerData data = SaveSystem.Load();

        CircleSpawner.currentDay = data.currentDay;
        range = data.range;
        fireRate = data.fireRate;
        damage = data.damage;
        maxHealth = data.maxHealth;
        health = data.health;
        critical = data.critical;
        PlayerStats.coin = data.coin;
        gameSpeed = data.gameSpeed;

        return data.hasData;
    }
    public static void ResetGame()
    {
        // Reset variables to their initial values
        range = 15f;
        fireRate = 1f;
        damage = 50;
        maxHealth = 100;
        health = maxHealth; // Reset health to maxHealth
        critical = 0.0f;
        gameSpeed = 1.0f;
        CircleSpawner.currentDay = 1;
        PlayerStats.coin = 400;

        
    }
}
