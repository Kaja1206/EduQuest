using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManage : MonoBehaviour
{

    public static bool isGameOver;
    public GameObject gameOverScreen;

    public static Vector2 lastCP = new Vector2(-11, -3);

    public static int NoOfCoins;
    public TextMeshProUGUI CoinsTxt;
    

    private void Awake()
    {
        isGameOver = false;

        GameObject.FindGameObjectWithTag("Player").transform.position = lastCP;
    }

    void Start()
    {
        
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
}
