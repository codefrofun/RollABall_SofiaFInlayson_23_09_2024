using UnityEngine;

public class DoorDisappear : MonoBehaviour
{
    public GameObject targetObject;
    private bool hasDisappeared = false;

    void Start()
    {
        targetObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasDisappeared)
        {
            targetObject.SetActive(false);
            hasDisappeared = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Optionally, you can keep this empty or handle other logic if needed
    }
}

