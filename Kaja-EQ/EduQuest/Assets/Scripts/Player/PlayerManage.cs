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
    public static int totalMarks = 0; // Total marks scored
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
        // Reset the game state when restarting the game
        ResetGameState();
        Time.timeScale = 1;
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
        // Reset the game state when going to the main menu
        ResetGameState();
        SceneManager.LoadScene("MathsMenu");
        AudioListener.pause = false;
    }

    public void GotoEngMenu()
    {
        // Reset the game state when going to the main menu
        ResetGameState();
        SceneManager.LoadScene("EnglishMenu");
        AudioListener.pause = false;
    }

    public static void ResetGameState()
    {
        // Reset all game state variables
        NoOfCoins = 0;
        totalMarks = 0;
        PlayerPrefs.DeleteKey("CheckpointCoins");
        PlayerPrefs.SetInt("NoOfCoins", NoOfCoins);
        lastCP = new Vector2(-11, -3); // Reset checkpoint to initial position

        // Clear all checkpoint activation states
        ClearCheckpointData();
    }

    // Make this method static
    private static void ClearCheckpointData()
    {
        // Find all checkpoints in the scene and clear their activation states
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        foreach (GameObject checkpoint in checkpoints)
        {
            PlayerPrefs.DeleteKey("CheckpointActivated_" + checkpoint.name);
        }
    }

    private void OnApplicationQuit()
    {
        // Ensure the coin count is reset when the game quits from the editor
        NoOfCoins = 0;
        PlayerPrefs.SetInt("NoOfCoins", NoOfCoins);
        PlayerPrefs.DeleteKey("CheckpointCoins");

        // Clear all checkpoint activation states
        ClearCheckpointData();
    }

    private void OnDestroy()
    {
        // Save the total number of coins when the player object is destroyed
        PlayerPrefs.SetInt("NoOfCoins", NoOfCoins);
    }
}