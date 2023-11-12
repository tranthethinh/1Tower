using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    public TMP_Text textAttackSpeed;
    public TMP_Text textDamage;
    public TMP_Text textRange;
    public TMP_Text textCrit;
    public TMP_Text textMaxHealth;
    public TMP_Text textCurrentDay;
    public TMP_Text textHpBar;
    public TMP_Text textMoney;
    public TMP_Text textMaxGameSpeed;
    public TMP_Text textCurrentGameSpeed;

    private Tower tower;
    public GameObject bulletPrefab; // Assign the bullet prefab in the Inspector
    //private Bullet bullet;
    private CircleSpawner daySpawn;


    public GameObject DamageTextPrefab;
    public Canvas gameCanvas;
    void Start()
    {

        //bullet = bulletPrefab.GetComponent<Bullet>();
        tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();
        //daySpawn = GameObject.Find("GameManager").GetComponent<CircleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        textAttackSpeed.text =  Tower.fireRate.ToString("F1");
        textDamage.text = Tower.damage.ToString();
        // using private getdamage 


        textMoney.text ="Money: " + PlayerStats.coin;
        textCurrentDay.text = "Day\n" + CircleSpawner.currentDay;
        textRange.text = Tower.range.ToString("F1");
        textMaxHealth.text = Mathf.FloorToInt(Tower.maxHealth).ToString();
        textHpBar.text = Mathf.FloorToInt(Tower.health).ToString() + "/" + Mathf.FloorToInt(Tower.maxHealth).ToString();
        textCrit.text = Tower.critical.ToString("F1");
        textMaxGameSpeed.text = ButtonManager.currentMaxTimeScale.ToString();
        textCurrentGameSpeed.text = Time.timeScale.ToString();
    }
    public void ShowDamageText(GameObject spawnPosition, float damageReceive, bool isCritical)
    {
        Vector2 _spawnPosition = Camera.main.WorldToScreenPoint(spawnPosition.transform.position);
        TMP_Text tmpText = Instantiate(DamageTextPrefab, _spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        tmpText.text = damageReceive.ToString();

        if (isCritical)
        {
            // Set large size and red color for critical hits
            tmpText.fontSize = 36;  // You can adjust the font size as needed
            tmpText.color = Color.red;
        }
        else
        {
            // Set smaller size and orange color for non-critical hits
            tmpText.fontSize = 24;  // You can adjust the font size as needed
            tmpText.color = new Color(1.0f, 0.5f, 0.0f);  // Orange color
        }
    }

}
