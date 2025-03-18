using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public QuestionData[] categories;
    public QuestionData selectedCategory;
    private int currentQuestionIndex = 0;

    public TextMeshProUGUI questionText;
    public Image questionImage;
    public Button[] replyButtons;

    [Header("Score")]
    public ScoreManager score;
    public int correctReply = 10;
    public int wrongReply = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI feedbackText;

    [Header("correctReplyIndex")]
    public int correctReplyIndex;
    int correctReplies;

    [Header("Game Finished Panel")]
    public GameObject GameFinished;

    void Start()
    {
        int selectedCategoryIndex = PlayerPrefs.GetInt("SelectedCategory", 0);
        GameFinished.SetActive(false);
        SelectCategory(selectedCategoryIndex);
        LoadProgress(selectedCategoryIndex);
    }

    public void SelectCategory(int categoryIndex)
    {
        selectedCategory = categories[categoryIndex];
        currentQuestionIndex = 0;
        correctReplies = 0;
        DisplayQuestion();
    }

    public void DisplayQuestion()
    {
        if (selectedCategory == null) return;

        ResetButtons();

        Question question = selectedCategory.questions[currentQuestionIndex];

        questionText.text = question.questionText;

        questionImage.sprite = question.questionImage;

        for (int i = 0; i < replyButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = replyButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.replies[i];
        }
        feedbackText.text = "";
    }

    public void OnReplySelected(int replyIndex)
    {
        AudioManager.Instance.PlaySFX("Click");

        if (replyIndex == selectedCategory.questions[currentQuestionIndex].correctReplyIndex)
        {
            score.AddScore(correctReply);
            correctReplies++;
            Debug.Log("Correct Reply!");
            AudioManager.Instance.PlaySFX("MissionCompleted");
            feedbackText.text = "Wow, Great!";
        }
        else
        {
            score.SubtractScore(wrongReply);
            Debug.Log("Wrong Reply!");
            feedbackText.text = "Better luck next time!";
        }

        StartCoroutine(NextQuestionWithDelay());
    }

    IEnumerator NextQuestionWithDelay()
    {
        yield return new WaitForSeconds(1.5f); // Adjust delay as needed

        currentQuestionIndex++;
        SaveProgress();

        if (currentQuestionIndex < selectedCategory.questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Quiz Finished!");
            ShowGameFinishedPanel();
        }
    }

    public void ShowCorrectReply()
    {
        correctReplyIndex = selectedCategory.questions[currentQuestionIndex].correctReplyIndex;

        for (int i = 0; i < replyButtons.Length; i++)
        {
            if (i == correctReplyIndex)
            {
                replyButtons[i].interactable = true;
            }
            else
            {
                replyButtons[i].interactable = false;
            }
        }
    }

    public void ResetButtons()
    {
        foreach (var button in replyButtons)
        {
            button.interactable = true;
        }
    }

    public void ShowGameFinishedPanel()
    {
        GameFinished.SetActive(true);
        scoreText.text = correctReplies + "/" + selectedCategory.questions.Length;
        AudioManager.Instance.PlaySFX("MissionCompleted");
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("LastQuestionIndex_" + selectedCategory.name, currentQuestionIndex);
        PlayerPrefs.Save();
    }

    private void LoadProgress(int categoryIndex)
    {
        string categoryName = categories[categoryIndex].name;
        currentQuestionIndex = PlayerPrefs.GetInt("LastQuestionIndex_" + categoryName, 0);

        DisplayQuestion();
    }
}