using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class EnglishGameManager : MonoBehaviour
{
    public QuestionData[] categories;
    public QuestionData selectedCategory;
    private int currentQuestionIndex = 0;

    public TextMeshProUGUI questionText;
    public Image questionImage;
    public Button[] replyButtons;

    [Header("Score")]
    public EnglishScoreManager score;
    public int correctReply = 10;
    public int wrongReply = 0;
    public TextMeshProUGUI scoreText;

    [Header("correctReplyIndex")]
    public int correctReplyIndex;
    int correctReplies;

    [Header("English Game Finished Panel")]
    public GameObject EnglishGameFinished;

    void Start()
    {
        int selectedCategoryIndex = PlayerPrefs.GetInt("SelectedCategory", 0);
        EnglishGameFinished.SetActive(false);
        SelectCategory(selectedCategoryIndex);
        LoadProgress(selectedCategoryIndex);
    }

    public void SelectCategory(int categoryIndex)
    {
        if (categoryIndex >= 0 && categoryIndex < categories.Length)
        {
            selectedCategory = categories[categoryIndex];
            currentQuestionIndex = 0;
            correctReplies = 0;
            DisplayQuestion();
        }
        else
        {
            Debug.LogError("Invalid category index: " + categoryIndex);
        }

    }

    public void DisplayQuestion()
    {
        if (selectedCategory == null || selectedCategory.questions == null || currentQuestionIndex < 0 || currentQuestionIndex >= selectedCategory.questions.Length)
        {
            Debug.LogError("DisplayQuestion: Invalid selectedCategory or question index.");
            return;
        }

        ResetButtons();

        Question question = selectedCategory.questions[currentQuestionIndex];

        if (question == null)
        {
            Debug.LogError("DisplayQuestion: Question at index " + currentQuestionIndex + " is null.");
            return;
        }

        questionText.text = question.questionText;
        questionImage.sprite = question.questionImage;

        for (int i = 0; i < replyButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = replyButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.replies[i];
        }
    }

    public void OnReplySelected(int replyIndex)
    {
        AudioManager.Instance.PlaySFX("Click");

        if (selectedCategory != null && selectedCategory.questions != null && currentQuestionIndex < selectedCategory.questions.Length && selectedCategory.questions[currentQuestionIndex] != null)
        {
            if (replyIndex == selectedCategory.questions[currentQuestionIndex].correctReplyIndex)
            {
                score.AddScore(correctReply);
                correctReplies++;
                Debug.Log("Correct Reply!");
                AudioManager.Instance.PlaySFX("MissionCompleted");
            }
            else
            {
                score.SubtractScore(wrongReply);
                Debug.Log("Wrong Reply!");
            }

            StartCoroutine(NextQuestionWithDelay());
        }
        else
        {
            Debug.LogError("Error: Invalid question data or index.");
        }
    }

    IEnumerator NextQuestionWithDelay()
    {
        yield return new WaitForSeconds(1.5f);

        currentQuestionIndex++;
        SaveProgress();

        if (currentQuestionIndex < selectedCategory.questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Quiz Finished!");
            EnglishShowGameFinishedPanel();
        }
    }

    public void EnglishShowCorrectReply()
    {
        if (selectedCategory != null && selectedCategory.questions != null && currentQuestionIndex < selectedCategory.questions.Length && selectedCategory.questions[currentQuestionIndex] != null)
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
        else
        {
            Debug.LogError("EnglishShowCorrectReply: Invalid selectedCategory or question index.");
        }
    }

    public void ResetButtons()
    {
        foreach (var button in replyButtons)
        {
            button.interactable = true;
        }
    }

    public void EnglishShowGameFinishedPanel()
    {
        EnglishGameFinished.SetActive(true);
        scoreText.text = correctReplies + "/" + selectedCategory.questions.Length;
        AudioManager.Instance.PlaySFX("MissionCompleted");
    }

    public void SaveProgress()
    {
        if (selectedCategory != null)
        {
            PlayerPrefs.SetInt("LastQuestionIndex_" + selectedCategory.name, currentQuestionIndex);
            PlayerPrefs.Save();
        }
    }

    private void LoadProgress(int categoryIndex)
    {
        if (categoryIndex >= 0 && categoryIndex < categories.Length)
        {
            string categoryName = categories[categoryIndex].name;
            currentQuestionIndex = PlayerPrefs.GetInt("LastQuestionIndex_" + categoryName, 0);

            if (selectedCategory != null && selectedCategory.questions != null && currentQuestionIndex >= selectedCategory.questions.Length)
            {
                currentQuestionIndex = 0;
            }

            DisplayQuestion();
        }
        else
        {
            Debug.LogError("LoadProgress: Invalid category index: " + categoryIndex);
        }
    }
}