using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class PLayerControllerNoText : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private AudioSource pop;
    public GameObject mainCamera;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
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
        countText.text = "Count: " + count.ToString();
    }

    private void FixedUpdate()
    {
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // Create the movement direction based on camera orientation
        Vector3 movement = cameraForward * movementY + cameraRight * movementX;

        // Apply movement to the Rigidbody
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            pop.Play();

            SetCountText();
            if (count >= 5)
            {
                winTextObject.SetActive(true);
            } 
        }
    }
}

