using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurCameraController : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    private float scrollSpeed = 10f;
    private float rotateSpeed = 5f;

    void Update()
    {
        // Get the forward direction of the camera
        Vector3 forward = transform.forward;

        // Ignore the vertical component to move only on the horizontal plane
        forward.y = 0f;
        forward.Normalize();

        // Get the right direction of the camera
        Vector3 right = transform.right;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            // Move the camera based on keyboard input
            Vector3 moveDirection = (Input.GetAxisRaw("Horizontal") * right + Input.GetAxisRaw("Vertical") * forward).normalized;
            transform.position += moveSpeed * moveDirection;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            // Zoom the camera based on the mouse scroll wheel
            transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
        }

        // Rotate the camera based on horizontal mouse movement
        float rotateInput = Input.GetAxis("Mouse X");
        if (rotateInput != 0)
        {
            // Rotate the camera horizontally
            transform.Rotate(Vector3.up, rotateInput * rotateSpeed);
        }
    }
}
