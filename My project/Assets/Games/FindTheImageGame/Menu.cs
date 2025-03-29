using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Loads the "Category" scene when the Play button is clicked
    public void Play()
    {
        SceneManager.LoadScene("Category");
    }

    // Resets the quiz progress by deleting all stored PlayerPrefs data
    public void ResetQuiz()
    {
        PlayerPrefs.DeleteAll();
    }

    // Quits the application (only works in a built game, not in the Unity Editor)
    public void Quit()
    {
        Application.Quit();
    }
}
