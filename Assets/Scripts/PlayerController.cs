using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private AudioSource pop;
    public GameObject mainCamera;
    public bool FindSecret;

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
            count = count + 1;
            pop.Play();

            SetCountText();
            if (count == 6)
            {
                if (FindSecret == true)
                {
                    winTextObject.SetActive(true);
                    StartCoroutine(WaitToLoadScene());
                }
                else if (FindSecret == false)
                {
                    winTextObject.SetActive(true);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
        else if (other.gameObject.CompareTag("Secret"))
        {
            FindSecret = true;
            other.gameObject.SetActive(false);
            pop.Play();

            SetCountText();
        }

        static IEnumerator WaitToLoadScene()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
