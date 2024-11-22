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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sceneLoader = FindObjectOfType<LoadingScript>();
    }

    public void Collect()
    {
        collectableCount++;
        Debug.Log("Collectable Count: " + collectableCount);

        if (collectableCount == 5 || collectableCount == 6)
        {
            sceneLoader.CheckAndLoadScene(collectableCount);
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
}