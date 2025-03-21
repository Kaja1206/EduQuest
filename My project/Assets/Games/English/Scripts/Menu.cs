using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play ()
    {
        SceneManager.LoadScene("Category");
        AudioManager.Instance.PlaySFX("Click");
    }

    public void ResetQuiz()
    {
        PlayerPrefs.DeleteAll();
        AudioManager.Instance.PlaySFX("Click");
    }

    public void Exit()
    {
        Application.Quit();
        AudioManager.Instance.PlaySFX("Click");
    }
}
