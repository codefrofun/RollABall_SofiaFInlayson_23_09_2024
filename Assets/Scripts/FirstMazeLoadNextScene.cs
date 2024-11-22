using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstMazeLoadNextScene : MonoBehaviour
{
    public float timer;

    void Update()
    {
        timer = Time.timeSinceLevelLoad;

        if (timer >= 8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
