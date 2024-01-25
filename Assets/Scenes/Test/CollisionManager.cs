using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // List to keep track of all spawned objects
    private List<GameObject> spawnedObjects = new List<GameObject>();



    // Call this method to register spawned objects
    public void RegisterObject(GameObject obj)
    {
        if (!spawnedObjects.Contains(obj))
        {
            spawnedObjects.Add(obj);
        }
    }

    public void DeleteAllObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();
    }

    // Handle collision globally
    void HandleCollision(GameObject collidedObject)
    {
        // Add your custom logic here for handling collisions globally
        // For example, you can deactivate the Rigidbody of the collidedObject
        Rigidbody rb = collidedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    // This method is called when any object collides
    public void OnCollision(GameObject collidedObject)
    {
        // Call your global collision handling method
        HandleCollision(collidedObject);
    }
}
