using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpawnCoal : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawneePrefab;
    private int spawnable = 5650;
    private int spawned = 0;

    public TextMeshProUGUI country;
    public TextMeshProUGUI income;
    public CollisionManager collisionManager;
    
    public float randomRangeX = 5f;
    public float randomRangeY = 5f;
    public float randomRangeZ = 5f;
    private bool spawnEnabled = false; // Flag to control spawning
    private DataLoader dataLoader;
    void Start(){
                dataLoader = new DataLoader();
    }

    public void EnableSpawn()
    {
        List<Country> countryList = new List<Country>();
         countryList = dataLoader.LoadData();
         int grana;
         switch(income.text){
            case "low":
                grana = 1;
                break;
            case "medium":
                grana = 2;
                break;
            case "high":
                grana = 3;
                break;
            default:
                grana = 1;
                break;
         }
         Debug.Log(grana);
        spawnable = dataLoader.getRockCount(country.text, grana);
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