using UnityEngine;
using System.Collections;

public class CircleSpawner : MonoBehaviour
{
    public Transform center; // Center of the circle
    public float rangeSpawn = 5f; // Radius of the circle
    public int numberOfWavesPerDay = 3; // Number of waves per day
    public float timeBetweenWaves = 5f; // Delay between waves
    public float minObjectsToSpawn = 10; // Minimum number of objects to spawn in a wave (increased)
    public float maxObjectsToSpawn = 20; // Maximum number of objects to spawn in a wave (increased)
    public GameObject objectToSpawn;
    public GameObject EnemySpeed;
    public GameObject EnemyBoss;
    public static int currentDay = 1;
    private Vector2 spawnPosition;
    private void Start()
    {
       
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int wave = 0; wave < numberOfWavesPerDay; wave++)
            {
                

                int numberOfObjects = Random.Range((int)minObjectsToSpawn, (int)maxObjectsToSpawn);

                for (int i = 0; i < numberOfObjects; i++)
                {
                    float angle = Random.Range(0f, 360f);
                    float delay = Random.Range(0f, 2f);

                    yield return new WaitForSeconds(delay);

                    spawnPosition = center.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * rangeSpawn, Mathf.Sin(angle * Mathf.Deg2Rad) * rangeSpawn, 0f);
                    
                    if (currentDay % 3 == 0 && numberOfWavesPerDay==3)
                    {
                        if (Random.Range(0, 2) == 0)
                        {
                            Instantiate(EnemySpeed, spawnPosition, Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                        }
                    }
                    else
                    {
                        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                    }
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }

            currentDay++;
            if (currentDay % 10 == 0)
            {
                // Spawn a boss enemy
                Instantiate(EnemyBoss, spawnPosition, Quaternion.identity);
            }

        }
    }
    public int GetCurrentDay()
    {
        return currentDay;
    }
}
