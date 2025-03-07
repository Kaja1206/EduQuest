using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public Button playButton;

    private void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(StartGame);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("English");
    }
}