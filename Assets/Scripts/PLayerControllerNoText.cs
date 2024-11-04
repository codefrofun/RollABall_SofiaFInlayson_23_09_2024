using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UIElements;

public class PlayerControllerNoText : MonoBehaviour
{
    public float speed = 0;
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

        rb.AddForce(movement);

        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);



        /* Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = cameraForward * movementY + cameraRight * movementX;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); */
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
