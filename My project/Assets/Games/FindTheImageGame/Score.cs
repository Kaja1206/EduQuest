using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score; // Stores the player's current score
    public TextMeshProUGUI scoreText; // UI text element to display the score


    public const string ScoreKey = "Score"; // Key used to store the score in PlayerPrefs

    void Start()
    {
        LoadScore(); // Load previously saved score when the game starts
        UpdateScoreText(); // Update the UI to reflect the current score
    }

    // Adds points to the score and updates the display
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        SaveScore(); // Save the updated score
    }

    // Subtracts points from the score and updates the display
    public void SubtractScore(int points)
    {
        score -= points;
        UpdateScoreText();
        SaveScore(); // Save the updated score
    }

    // Updates the UI text to display the current score
    void UpdateScoreText()
    {
        scoreText.text = "" + score.ToString();
    }

    // Saves the current score using PlayerPrefs
    public void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save();
    }

    // Loads the previously saved score from PlayerPrefs
    public void LoadScore()
    {
        if (PlayerPrefs.HasKey(ScoreKey))
        {
            score = PlayerPrefs.GetInt(ScoreKey);
        }
        else
        {
            score = 0; // Default to 0 if no saved score is found
        }
    }

    // Resets the score and deletes all saved PlayerPrefs data
    public void ResetScore()
    {
        PlayerPrefs.DeleteAll(); // Deletes all stored PlayerPrefs data (might affect other saved data)
        score = 0; // Reset score to 0
        UpdateScoreText(); // Update the UI
    }

}
