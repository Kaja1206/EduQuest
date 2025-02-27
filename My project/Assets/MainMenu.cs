using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("Gr2 S1 L1");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Gr2 S1 L1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
