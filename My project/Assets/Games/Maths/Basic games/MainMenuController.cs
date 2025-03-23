using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadAdditionMenu()
    {
        SceneManager.LoadScene("AdditionMainMenu");
    }

    public void LoadSubtractionMenu()
    {
        SceneManager.LoadScene("SubMainMenu");
    }
}