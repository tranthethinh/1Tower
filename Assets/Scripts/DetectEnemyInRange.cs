
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyInRange : MonoBehaviour
{
    public List<GameObject> detectedEnemies = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Add the enemy to the list
            detectedEnemies.Add(other.gameObject);
        }
    }
    

    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            // Remove the enemy from the list when it exits the trigger
            detectedEnemies.Remove(other.gameObject);
        }
    }

}
