using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingPanel : MonoBehaviour
{
    public TextMeshProUGUI coinsText; // Text to display coins collected
    public TextMeshProUGUI scoreText; // Text to display total score

    private void OnEnable()
    {
        // Update the UI with the player's performance
        UpdateCoinsText();
        UpdateScoreText();
    }

    private void UpdateCoinsText()
    {
        // Always display coins in green
        coinsText.text = "Coins Collected: <color=green>" + PlayerManage.NoOfCoins + "</color>";
    }

    private void UpdateScoreText()
    {
        // Determine the color based on the score
        string color = (PlayerManage.totalMarks >= 5) ? "green" : "red";

        // Display the score and "/10" in the appropriate color
        scoreText.text = "Score: <color=" + color + ">" + PlayerManage.totalMarks + "</color><color=red>/10</color>";
    }


}