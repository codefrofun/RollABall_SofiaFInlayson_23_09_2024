using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenWorldMove : MonoBehaviour
{
    public float speed = 0;
    private AudioSource pop;
    public GameObject mainCamera;
    public bool FindSecret;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pop = GetComponent<AudioSource>();
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = cameraForward * movementY + cameraRight * movementX;

        // Apply movement to the Rigidbody
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        // Stop movement if there is no input
        if (movement == Vector3.zero)
        {
            rb.velocity = Vector3.zero; // Stop the Rigidbody
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            CollectableManager.Instance.Collect();
            pop.Play();
        }
    }
}