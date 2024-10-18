using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private AudioSource pop;
    public GameObject mainCamera;
    public int GateRestriction;

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

        /*if (count >= GateRestriction)
        {
            gameobject setactive(false);
        } */
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
        // Get the camera's forward and right directions
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        // Make the movement flat on the ground
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalize the vectors to avoid faster diagonal movement
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Create the movement direction based on camera orientation
        Vector3 movement = cameraForward * movementY + cameraRight * movementX;

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            pop.Play();

            SetCountText();
            if (count >= 12)
            {
                winTextObject.SetActive(true);
            }
        }
    }
}
