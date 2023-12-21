using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoal : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;
    private int spawnable = 1000;
    private int spawned = 0;
    // Update is called once per frame
    void Update()
    {
        if (spawnable >= spawned)
        {
            Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
            spawned += 1;
        }
    }
}
