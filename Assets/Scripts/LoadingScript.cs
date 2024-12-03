using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public void CheckAndLoadScene(int collectablesFound)
    {
        Debug.Log("CheckAndLoadScene called with " + collectablesFound + " collectables.");

        if (collectablesFound == 6)
        {
            // Call LoadNextScene directly instead of using Invoke for immediate transition
            Debug.Log("Player has found 6 collectables, loading next scene...");
            LoadNextScene();
        }
        else if (collectablesFound == 5)
        {
            // Call ReloadCurrentScene directly for 5 collectables
            Debug.Log("Player has found 5 collectables, reloading current scene...");
            ReloadCurrentScene();
        }
    }

    public void LoadNextScene()
    {
        // Debug log to check when the scene is being loaded
        Debug.Log("Loading next scene...");
        SceneManager.LoadScene("Loading Scene"); // Replace with your next scene name if necessary
    }

    public void ReloadCurrentScene()
    {
        // Debug log to check when the scene is being reloaded
        Debug.Log("Reloading current scene...");
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
