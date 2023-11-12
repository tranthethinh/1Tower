using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTower : MonoBehaviour
{
    public string targetTowerName = "Tower"; // The name of the tower GameObject

    private Transform targetTower; // Reference to the tower GameObject

    private Rigidbody2D rb;

    private Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();

        // Find the tower GameObject by name in the scene
        targetTower = GameObject.Find(targetTowerName)?.transform;

        if (targetTower == null)
        {
            Debug.LogWarning("Tower GameObject not found with the specified name: " + targetTowerName);
        }

        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component on the object
    }

    private void FixedUpdate()
    {
        if (targetTower != null)
        {
            // Calculate the direction from the current position to the tower
            Vector3 direction = targetTower.position - transform.position;
            direction.Normalize();

            // Move the object towards the tower
            //transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Calculate the velocity to move towards the tower
            Vector3 velocity = direction * enemy.speed;

            // Apply the velocity to the Rigidbody to move the object
            rb.velocity = velocity;
        }
    }
}
