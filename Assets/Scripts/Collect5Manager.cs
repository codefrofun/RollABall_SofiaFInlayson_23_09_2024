using UnityEngine;
using UnityEngine.SceneManagement;

public class Collect5Manager : MonoBehaviour
{
    public static Collect5Manager Instance;
    public int CollectableCount = 0;
    public GameObject door;
    public CollectablesLoadScene collectablesLoadScene;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Collect()
    {
        CollectableCount++;
    }

    public bool AllCollectablesCollected()
    {
        return CollectableCount >= 5;
    }

    public void TriggerDoor()
    {
        if (door != null && AllCollectablesCollected())
        {
            door.SetActive(false);
            Debug.Log("The door has disappeared.");


            if (collectablesLoadScene != null)
            {
                collectablesLoadScene.CheckAndLoadScene(true);
            }
            else
            {
                Debug.LogError("CollectablesLoadScene is not assigned in the Inspector.");
            }
        }
        else
        {
            Debug.Log("You must collect all the items before triggering the door.");
        }
    }

    public void CheckForDoorAndLoadScene()
    {

    }
}