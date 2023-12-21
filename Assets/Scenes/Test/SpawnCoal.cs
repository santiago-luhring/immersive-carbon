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

    void Update()
    {
        if (spawnable >= spawned)
        {
            // Introduce randomness to the spawn position
            Vector3 randomOffset = new Vector3(Random.Range(-0.5f, -0.5f), Random.Range(-0.5f, -0.5f), Random.Range(-0.5f, -0.5f));
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