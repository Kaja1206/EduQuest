using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnglishScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    public const string ScoreKey = "EnglishScore";

    void Start()
    {
        Debug.Log("ScoreManager Start: Instances=" + FindObjectsOfType<EnglishScoreManager>().Length);
        LoadScore();
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("AddScore: Adding " + points + " points. New score: " + score);
        UpdateScoreText();
        SaveScore();
    }

    public void SubtractScore(int points)
    {
        score -= points;
        Debug.Log("SubtractScore: Subtracting " + points + " points. New score: " + score);
        UpdateScoreText();
        SaveScore();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "" + score.ToString();
        }
        Debug.Log("UpdateScoreText: Score text updated to: " + score);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save();
        Debug.Log("SaveScore: Score saved to PlayerPrefs: " + score);
    }

    public void LoadScore()
    {
        if (PlayerPrefs.HasKey(ScoreKey))
        {
            score = PlayerPrefs.GetInt(ScoreKey);
            Debug.Log("LoadScore: Score loaded from PlayerPrefs: " + score);
        }
        else
        {
            score = 0;
            Debug.Log("LoadScore: No saved score, setting to 0.");
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        score = 0;
        UpdateScoreText();
        Debug.Log("ResetScore: Score reset to 0.");
    }
}