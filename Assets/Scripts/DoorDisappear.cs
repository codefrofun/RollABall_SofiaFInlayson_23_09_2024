using UnityEngine;

public class DoorDisappear : MonoBehaviour
{
    public GameObject targetObject;
    public bool hasDisappeared = false;
    public CollectablesLoadScene collectablesLoadScene;

    void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Target Object (door) is not assigned in the Inspector.");
        }

        if (collectablesLoadScene == null)
        {
            Debug.LogError("CollectablesLoadScene reference is missing. Please assign it in the Inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger entered by the player!");

            if (!hasDisappeared && CollectableManager.Instance != null && CollectableManager.Instance.AllCollectablesCollected())
            {
                Debug.Log("All collectables collected! Hiding door.");
                if (targetObject != null)
                {
                    targetObject.SetActive(false);
                    hasDisappeared = true;

                    if (collectablesLoadScene != null)
                    {
                        collectablesLoadScene.CheckAndLoadScene(hasDisappeared);
                    }
                    else
                    {
                        Debug.LogError("CollectablesLoadScene is null.");
                    }
                }
                else
                {
                    Debug.LogError("Target object (door) is null.");
                }
            }
            else
            {
                if (CollectableManager.Instance == null)
                {
                    Debug.LogError("CollectableManager.Instance is null. Make sure the instance is properly initialized.");
                }
                if (hasDisappeared)
                {
                    Debug.LogWarning("The door has already disappeared.");
                }
            }
        }
    }
}
