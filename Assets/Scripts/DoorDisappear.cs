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
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger entered by the player!");
            if (!hasDisappeared && CollectableManager.Instance.AllCollectablesCollected())
            {
                Debug.Log("All collectables collected! Hiding door.");
                targetObject.SetActive(false);
                hasDisappeared = true;
            }
        }
    }
}