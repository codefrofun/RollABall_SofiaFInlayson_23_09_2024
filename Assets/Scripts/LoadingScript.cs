using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{

    public float timer;

    // Start is called before the first frame update
    void Update()
    {
        timer = Time.timeSinceLevelLoad;

        if (timer >= 9)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
