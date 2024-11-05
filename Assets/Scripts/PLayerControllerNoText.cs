using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControllerNoText : MonoBehaviour
{
    public float speed = 7f; // Normal movement speed
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private AudioSource pop;
    public GameObject mainCamera;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pop = GetComponent<AudioSource>();

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + CollectableManager.Instance.CollectableCount.ToString();
    }

    private void FixedUpdate()
    {
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        // Zero out the vertical axis so we don't move up/down based on camera pitch
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalize the vectors to ensure consistent movement speed
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate movement based on player input and camera direction
        Vector3 movement = cameraForward * movementY + cameraRight * movementX;

        // Apply the normal speed to the movement vector
        Vector3 velocity = movement * speed;

        // Apply the velocity to the Rigidbody directly
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z); // Keep y-axis velocity for gravity, etc.
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            CollectableManager.Instance.Collect();
            pop.Play();
            SetCountText(); // Update the text after collecting
            if (CollectableManager.Instance.AllCollectablesCollected())
            {
                winTextObject.SetActive(true);
            }
        }
    }
}