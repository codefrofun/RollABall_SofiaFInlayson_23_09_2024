using UnityEngine;

public class DoorDisappear : MonoBehaviour
{
    public GameObject targetObject;
    public bool hasDisappeared = false;
    public CollectablesLoadScene collectablesLoadScene;

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
                targetObject.SetActive(false);  // Hide the door object
                hasDisappeared = true;  // Mark the door as disappeared

                if (collectablesLoadScene != null)
                {
                    collectablesLoadScene.CheckAndLoadScene(hasDisappeared);
                }
                else
                {
                    Debug.LogError("CollectablesLoadScene reference is missing. Please assign it in the Inspector.");
                }
            }
        }
    }
}

