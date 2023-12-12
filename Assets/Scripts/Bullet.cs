using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    private float speed = 7f;

    public float damage;
    public float critical;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    private Tower tower;
    void Start()
    {
        tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();

        //set damage 
        damage = Tower.damage;
        //set crit
        critical = Tower.critical;

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;


        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {

            Destroy(gameObject);
            Enemy enemy = col.GetComponent<Enemy>();
            bool isOneHit = Random.Range(0f, 100f) < Tower.oneHitPersentage;
            if (isOneHit)
            {
                //Destroy(col.gameObject);
                enemy.Die();
                
            }
            else
            {
                
                bool isCritical = Random.Range(0f, 100f) < critical;
                

                enemy.TakeDamage(damage, isCritical);
            }
            
            
        }
    }
    
}
