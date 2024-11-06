using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;  // For scene management

public class MovingText : MonoBehaviour
{
    public TextMesh loadingText;  // Reference to the TextMesh component
    public float loadingDuration = 5f;  // Duration of the loading screen
    public float textInterval = 1f;  // Interval for text disappearing and reappearing (in seconds)

    // Start is called before the first frame update
    void Start()
    {
        // Start the loading screen animation and scene loading
        StartCoroutine(LoadingScreenCoroutine());
    }

    IEnumerator LoadingScreenCoroutine()
    {
        float elapsedTime = 0f;  // Track elapsed time

        // Continue the animation while the loading duration is not finished
        while (elapsedTime < loadingDuration)
        {
            // Display text
            loadingText.text = "Loading...";
            yield return new WaitForSeconds(textInterval);  // Wait for the display interval

            // Hide text
            loadingText.text = "";
            yield return new WaitForSeconds(textInterval);  // Wait for the hide interval

            // Increment the elapsed time (text showed and hidden counts as two intervals)
            elapsedTime += textInterval * 2;
        }

        // After the loading is complete, load the next scene
        LoadNextScene();
    }

    void LoadNextScene()
    {
        // Replace "NextScene" with the actual name of your scene
        SceneManager.LoadScene("NextScene");  // Load the next scene
    }
}


