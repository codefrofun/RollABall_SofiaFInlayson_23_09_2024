using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public float timer;

    void Update()
    {
        timer = Time.timeSinceLevelLoad;

        if (timer >= 9)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void CheckAndLoadScene(int collectablesFound)
    {
        if (collectablesFound == 6)
        {
            LoadNextScene();
        }
        else if (collectablesFound == 5)
        {
            ReloadCurrentScene();
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