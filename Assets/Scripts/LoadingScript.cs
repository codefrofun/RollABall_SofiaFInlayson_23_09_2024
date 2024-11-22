using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public void CheckAndLoadScene(int collectablesFound)
    {
        if (collectablesFound == 6)
        {
            Invoke("LoadNextScene", 6f);
        }
        else if (collectablesFound == 5)
        {
            Invoke("ReloadCurrentScene", 6f);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Secret Maze");
    }

    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}