using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance;

    public int collectableCount = 0;
    public int totalCollectables = 5;

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

    public void Collect()
    {
        collectableCount++;
        Debug.Log("Collectable Count: " + collectableCount); // Debug log to verify count
    }

    public bool AllCollectablesCollected()
    {
        return collectableCount >= totalCollectables;
    }

    public int CollectableCount => collectableCount; // Expose the count
}