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
    public TextMeshProUGUI totalRocks;
    public CollisionManager collisionManager;

    public SoundManager soundManager;
    private bool TurnAudioOn = true;
    
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
        spawned = 0;
        collisionManager.DeleteAllObjects();
        List<Country> countryList = new List<Country>();
         countryList = dataLoader.LoadData();
         int grana;
         Debug.Log("income text: "+ income.text);
         switch(income.text){
            case "Decile 1 (Lowest)":
                grana = 1;
                break;
            case "Decile 2":
                grana = 2;
                break;
            case "Decile 3":
                grana = 3;
                break;
            case "Decile 4":
                grana = 4;
                break;
            case "Decile 5":
                grana = 5;
                break;
            case "Decile 6":
                grana = 6;
                break;
            case "Decile 7":
                grana = 7;
                break;
            case "Decile 8":
                grana = 8;
                break;
            case "Decile 9":
                grana = 9;
                break;
            case "Decile 10 (Highest)":
                grana = 10;
                break;
            default:
                grana = 1;
                break;
         }
         Debug.Log("income level: " + grana);
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
            Vector3 randomOffset = new Vector3(Random.Range(-randomRangeX, randomRangeX), 10, Random.Range(-randomRangeZ, randomRangeZ));
            Vector3 spawnPosition = spawnPos.position + randomOffset;

            // Instantiate the object at the modified spawn position
            GameObject spawnedObject = Instantiate(spawneePrefab, spawnPosition, spawnPos.rotation);

            // Register the spawned object with the CollisionManager
            if (collisionManager != null)
            {
                collisionManager.RegisterObject(spawnedObject);
            }
            if (TurnAudioOn)
            {
                soundManager.PlaySoundEffect();
                TurnAudioOn = false;
            }

            spawned += 1;
            totalRocks.text = "Generated CO2 in Kg: " + (spawned*10);
        }
        if (spawnable <= spawned){
            soundManager.StopSoundEffect();
            spawned = 0;
            spawnEnabled = false;
            TurnAudioOn = true;
        }
    }
}