using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public QuestionData[] categories;
    public QuestionData selectedCategory;

    private int currentQuestionIndex = 0;

    public TMP_Text questionText;
    public Image questionImage;
    public Button[] replyButtons;

    void Start()
    {
        SelectCategory(0);
    }
    public void SelectCategory(int categoryIndex)
    {
        selectedCategory = categories[categoryIndex];
        currentQuestionIndex = 0;
        DisplayQuestion();
    }

    public void DisplayQuestion()
    {
        if (selectedCategory == null) return;

        var question = selectedCategory.questions[currentQuestionIndex];

        questionText.text = question.questionText;

        questionImage.sprite = question.questionImage;

        for (int i = 0; i < replyButtons.Length; i++)
        {
            TMP_Text buttonText = replyButtons[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = question.replies[i];
        }
    }

    public void OnRelySelected(int replyIndex)
    {
        if (replyIndex == selectedCategory.questions[currentQuestionIndex].correctReplyIndex)
        {
            Debug.Log("Correct Reply!");
        }
        else
        {
            Debug.Log("Wrong Reply!");
        }

        currentQuestionIndex++;
        if (currentQuestionIndex < selectedCategory.questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Quiz Finished!");
        }
    }
}
