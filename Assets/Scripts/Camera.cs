using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float mouseSensitivity = 100f; // Sensitivity for mouse movement
    private Vector3 offset;
    private float rotationX = 0f;

    private void Start()
    {
        offset = transform.position - player.transform.position;

        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera around the player
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limit vertical rotation

        // Apply rotation to the camera
        transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y + mouseX, 0f);

        // Update camera position
        transform.position = player.transform.position + offset;
    }
}