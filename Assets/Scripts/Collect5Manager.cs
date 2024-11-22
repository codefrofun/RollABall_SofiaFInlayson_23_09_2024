using UnityEngine;

public class Collect5Manager : MonoBehaviour
{
    public static Collect5Manager Instance;

    public int collectableCount = 0;
    public int totalCollectables = 5;

    private CollectablesLoadScene sceneLoader;
    public GameObject door;

    private bool doorTriggered = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Collect5Manager instance created.");
        }
        else
        {
            Debug.LogError("Duplicate Collect5Manager instance detected and destroyed.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sceneLoader = FindObjectOfType<CollectablesLoadScene>();
        if (sceneLoader == null)
        {
            Debug.LogError("CollectablesLoadScene not found in the scene.");
        }

        if (door == null)
        {
            Debug.LogError("Door GameObject is not assigned in Collect5Manager.");
        }
    }

    public void Collect()
    {
        collectableCount++;
        Debug.Log("Collectable Count: " + collectableCount);

        if (collectableCount == totalCollectables)
        {
            if (door != null)
            {
                door.SetActive(false);
            }
        }
    }

    public bool AllCollectablesCollected()
    {
        return collectableCount >= totalCollectables;
    }

    public int CollectableCount => collectableCount;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
            Destroy(gameObject);
        }
    }

    public void CheckForDoorAndLoadScene()
    {
        if (collectableCount == totalCollectables && door != null && !door.activeSelf && doorTriggered)
        {
            if (sceneLoader != null)
            {
                sceneLoader.CheckAndLoadScene(true);
            }
            else
            {
                Debug.LogError("SceneLoader is not assigned.");
            }
        }
    }

    public void TriggerDoor()
    {
        doorTriggered = true;
        CheckForDoorAndLoadScene();
    }
}
