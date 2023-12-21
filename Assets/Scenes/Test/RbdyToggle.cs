using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbdyToggle : MonoBehaviour
{
    private Rigidbody rb;
    private CollisionManager collisionManager;
    public float delay = 1.0f;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Find the CollisionManager in the scene
        collisionManager = FindObjectOfType<CollisionManager>();

        // Register this object with the CollisionManager
        if (collisionManager != null)
        {
            collisionManager.RegisterObject(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the specified target GameObject
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Start the DelayedDeactivation coroutine
            StartCoroutine(DelayedDeactivation());
        }
    }

    // Coroutine for delayed deactivation
    IEnumerator DelayedDeactivation()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Deactivate the Rigidbody
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}