using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountingScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    public const string ScoreKey = "Score";

    void Start()
    {
        LoadScore();
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        SaveScore();
    }

    public void SubtractScore(int points)
    {
        score -= points;
        UpdateScoreText();
        SaveScore();
    }

    void UpdateScoreText()
    {
        scoreText.text = "" + score.ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        if (PlayerPrefs.HasKey(ScoreKey))
        {
            score = PlayerPrefs.GetInt(ScoreKey);
        }
        else
        {
            score = 0;
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        score = 0;
        UpdateScoreText();
    }
}