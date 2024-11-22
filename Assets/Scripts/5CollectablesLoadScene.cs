using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectablesLoadScene : MonoBehaviour
{
    public void CheckAndLoadScene(bool hasDisappeared)
    {
        if (hasDisappeared)
        {
            Invoke("LoadNextScene", 10f);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Open World...");
    }
}