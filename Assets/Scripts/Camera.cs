using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = Mathf.Clamp(y, -20, 80);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        // Calculate the desired camera position
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 desiredPosition = player.transform.position - rotation * Vector3.forward * distance;

        // Raycast to check for obstacles
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, (desiredPosition - player.transform.position).normalized, out hit, distance))
        {
            // If there's an obstacle, adjust the position to the hit point
            transform.position = hit.point;
        }
        else
        {
            // If no obstacle, set the camera to the desired position
            transform.position = desiredPosition;
        }

        // Always look at the player
        transform.rotation = rotation;
    }
}
