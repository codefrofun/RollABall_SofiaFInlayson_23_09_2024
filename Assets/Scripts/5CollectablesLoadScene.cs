using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectablesLoadScene : MonoBehaviour
{
    public void CheckAndLoadScene(bool hasDisappeared)
    {
        if (hasDisappeared)
        {
            Debug.Log("Waiting for 10 seconds before loading the next scene...");
            Invoke("LoadNextScene", 10f); // Delay the scene load by 10 seconds
        }
    }

    public void LoadNextScene()
    {
        Debug.Log("Loading the next scene...");
        SceneManager.LoadScene("LoadingOpen");
    }
}