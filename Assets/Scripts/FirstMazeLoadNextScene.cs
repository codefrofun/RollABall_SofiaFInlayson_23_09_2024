using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstMazeLoadNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadSecretMaze()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
