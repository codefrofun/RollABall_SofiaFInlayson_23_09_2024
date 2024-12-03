using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance;

    public int collectableCount = 0;
    public int totalCollectables = 6;

    private LoadingScript sceneLoader;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("CollectableManager instance created.");
        }
        else
        {
            Debug.LogError("Duplicate CollectableManager instance detected and destroyed.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sceneLoader = FindObjectOfType<LoadingScript>();
        Debug.Log("SceneLoader: " + (sceneLoader != null ? "Found" : "Not Found"));
    }

    public void Collect()
    {
        collectableCount++;
        Debug.Log("Collectable Count: " + collectableCount);  // Log the updated collectable count

        // Call CheckAndLoadScene every time the collectable count changes
        if (sceneLoader != null)
        {
            sceneLoader.CheckAndLoadScene(collectableCount);
        }
        else
        {
            Debug.LogError("sceneLoader is null!");
        }
    }

    public bool AllCollectablesCollected()
    {
        return collectableCount >= totalCollectables;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
            Destroy(gameObject);
        }
    }
}
