using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoal : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawneePrefab;
    private int spawnable = 5650;
    private int spawned = 0;
    public CollisionManager collisionManager;
    
    public float randomRangeX = 5f;
    public float randomRangeY = 5f;
    public float randomRangeZ = 5f;

    void Update()
    {
        if (spawnable >= spawned)
        {
            // Introduce randomness to the spawn position   
            Vector3 randomOffset = new Vector3(Random.Range(-randomRangeX, randomRangeX), Random.Range(-randomRangeY, randomRangeY), Random.Range(-randomRangeZ, randomRangeZ));
            Vector3 spawnPosition = spawnPos.position + randomOffset;

            // Instantiate the object at the modified spawn position
            GameObject spawnedObject = Instantiate(spawneePrefab, spawnPosition, spawnPos.rotation);

            // Register the spawned object with the CollisionManager
            if (collisionManager != null)
            {
                collisionManager.RegisterObject(spawnedObject);
            }

            spawned += 1;
        }
    }
}