using PlayerControlsNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenWorldMove : MonoBehaviour
{
    public float speed = 7;
    public float runSpeed = 14;
    private AudioSource pop;
    public GameObject mainCamera;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool isRunning = false;

    private PlayerControlsName controls;

    void Awake()
    {
        controls = new PlayerControlsName();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pop = GetComponent<AudioSource>();

        controls.Player.Sprint.performed += _ => isRunning = true;
        controls.Player.Sprint.canceled += _ => isRunning = false;
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

        float currentSpeed = isRunning ? runSpeed : speed;

        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);

        if (movement == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
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
