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
    private DataLoader dataLoader; 
    
    public float randomRangeX = 5f;
    public float randomRangeY = 5f;
    public float randomRangeZ = 5f;
    private bool spawnEnabled = false; // Flag to control spawning

    void Start()
    {   
        dataLoader = new DataLoader();
        
         List<Country> countryList = new List<Country>();
         countryList = dataLoader.LoadData();
         int rocks = dataLoader.getRockCount("EUA",3);
         Debug.Log("AAAAAAAAAA " + rocks);
    }

    public void EnableSpawn()
    {
        spawnEnabled = true;
    }
    void Update()
    {
        // Check for spacebar press to enable spawning
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    spawnEnabled = true;
        //}

        // Check if spawning is enabled
        if (spawnEnabled && spawnable >= spawned)
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