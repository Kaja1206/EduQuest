using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManage : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenu;

    public static Vector2 lastCP = new Vector2(-11, -3);
    public static int NoOfCoins;
    public TextMeshProUGUI CoinsTxt;

    private void Awake()
    {
        isGameOver = false;

        // Initialize the coin count based on whether there's a saved checkpoint
        if (PlayerPrefs.HasKey("CheckpointCoins"))
        {
            NoOfCoins = PlayerPrefs.GetInt("CheckpointCoins", 0);
        }
        else
        {
            NoOfCoins = 0;
        }

        GameObject.FindGameObjectWithTag("Player").transform.position = lastCP;
    }

    void Update()
    {
        CoinsTxt.text = NoOfCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLev1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        // Reset the coin count when restarting the game
        NoOfCoins = 0;
        PlayerPrefs.DeleteKey("CheckpointCoins");
        PlayerPrefs.SetInt("NoOfCoins", NoOfCoins);
        lastCP = new Vector2(-11, -3); // Reset checkpoint to initial position
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        AudioListener.pause = false;
    }

    public void GotoMenu()
    {
        // Reset the coin count when going to the main menu
        NoOfCoins = 0;
        PlayerPrefs.DeleteKey("CheckpointCoins");
        PlayerPrefs.SetInt("NoOfCoins", NoOfCoins);
        lastCP = new Vector2(-11, -3); // Reset checkpoint position to the initial position or any default position
        SceneManager.LoadScene("Menu");
        AudioListener.pause = false;
    }

    private void OnApplicationQuit()
    {
        // Ensure the coin count is reset when the game quits from the editor
        NoOfCoins = 0;
        PlayerPrefs.SetInt("NoOfCoins", NoOfCoins);
        PlayerPrefs.DeleteKey("CheckpointCoins");
    }

    private void OnDestroy()
    {
        // Save the total number of coins when the player object is destroyed
        PlayerPrefs.SetInt("NoOfCoins", NoOfCoins);
    }
}
