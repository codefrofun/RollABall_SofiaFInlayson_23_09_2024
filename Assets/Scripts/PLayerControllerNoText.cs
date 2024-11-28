using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerControllerNoText : MonoBehaviour
{
    public float speed = 7f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private AudioSource pop;
    public GameObject mainCamera;
    public GameObject door;

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
        countText.text = "Count: " + Collect5Manager.Instance.CollectableCount.ToString();
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
        Vector3 velocity = movement * speed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (Collect5Manager.Instance != null)
            {
                other.gameObject.SetActive(false);
                Collect5Manager.Instance.Collect();
                pop.Play();
                SetCountText();

                if (Collect5Manager.Instance.AllCollectablesCollected())
                {
                    winTextObject.SetActive(true);
                }
            }
            else
            {
                Debug.LogError("Collect5Manager.Instance is null. Please make sure Collect5Manager is in the scene.");
            }
        }

        if (other.gameObject.CompareTag("Door"))
        {
            if (Collect5Manager.Instance != null && Collect5Manager.Instance.AllCollectablesCollected())
            {
                Collect5Manager.Instance.TriggerDoor();
            }
            else
            {
                Debug.Log("You need to collect all items before accessing the door.");
            }
        }
    }
}
