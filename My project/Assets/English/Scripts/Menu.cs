using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play ()
    {
        SceneManager.LoadScene("Category");
    }

    public void ResetQuiz()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
