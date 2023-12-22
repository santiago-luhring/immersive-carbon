using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbdyToggle : MonoBehaviour
{
    private Rigidbody rb;
    private CollisionManager collisionManager;

    public float stopThreshold = 0.1f; // Adjust the threshold for considering the object stopped
    public float deactivationDuration = 3f; // Adjust the duration for considering the object stopped
    private float timeBelowThreshold = 0f; // Timer for tracking duration below the threshold

    public LayerMask groundLayer; // Specify the ground layer

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Find the CollisionManager in the scene using FindObjectOfType
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
            // Deactivate the Rigidbody immediately on collision
            DeactivateRigidbody();
        }

        // Check if the collision is with the ground (based on the specified ground layer)
        if ((groundLayer.value & 1 << collision.gameObject.layer) != 0)
        {
            // Deactivate the Rigidbody on collision with the ground
            DeactivateRigidbody();
        }
    }

    void Update()
    {
        // Check if the object's velocity is below the stop threshold
        if (rb != null && rb.velocity.magnitude < stopThreshold)
        {
            // Increment the timer for tracking duration below the threshold
            timeBelowThreshold += Time.deltaTime;

            // Check if the duration below the threshold exceeds the deactivation duration
            if (timeBelowThreshold >= deactivationDuration)
            {
                // Deactivate the Rigidbody if the duration threshold is reached
                DeactivateRigidbody();
            }
        }
        else
        {
            // Reset the timer if the velocity is above the threshold
            timeBelowThreshold = 0f;
        }
    }

    // Method to deactivate the Rigidbody
    public void DeactivateRigidbody()
    {
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}