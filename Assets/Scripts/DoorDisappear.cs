using UnityEngine;
using System.Collections;

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
        if (other.CompareTag("Player") && !hasDisappeared)
        {
            Debug.Log("Trigger entered by the player!");

            if (CollectableManager.Instance != null && CollectableManager.Instance.AllCollectablesCollected())
            {
                if (targetObject != null)
                {
                    targetObject.SetActive(false);
                    hasDisappeared = true;

                    // Start the coroutine to load the next scene after a delay
                    StartCoroutine(LoadNextSceneAfterDelay(10f));
                }
            }
        }
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (collectablesLoadScene != null)
        {
            collectablesLoadScene.CheckAndLoadScene(true);
        }
    }
}