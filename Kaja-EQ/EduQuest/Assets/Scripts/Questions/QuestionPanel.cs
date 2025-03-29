using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionPanel : MonoBehaviour
{
    public TextMeshProUGUI questionText; // Text to display the question
    public Button[] answerButtons; // Buttons for answers (4 buttons)
    public GameObject correctAnswerPanel; // Panel to show if the answer is correct
    public GameObject wrongAnswerPanel; // Panel to show if the answer is wrong
    public Button correctResumeButton; // Resume button in the correct panel
    public Button wrongResumeButton; // Resume button in the wrong panel
    public QuestionManager questionManager; // Reference to the QuestionManager

    private Question currentQuestion; // The current question being displayed
    private float startTime; // Time when the question is displayed
    private int nextQuestionDifficulty = 1; // Default difficulty for the next question (1 = Easy, 2 = Medium, 3 = Hard)

    // Map difficulty index to its name
    private string[] difficultyNames = { "Easy", "Medium", "Hard" };

    private void Start()
    {
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);

        correctResumeButton.onClick.AddListener(ResumeGame);
        wrongResumeButton.onClick.AddListener(ResumeGame);
    }

    private void OnEnable()
    {
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        if (questionManager == null)
        {
            return;
        }

        currentQuestion = questionManager.GetQuestionByDifficulty(nextQuestionDifficulty);

        if (currentQuestion != null)
        {
            questionText.text = currentQuestion.questionText;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < currentQuestion.answers.Length)
                {
                    answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[i];
                    answerButtons[i].gameObject.SetActive(true);
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false);
                }
            }

            startTime = Time.time;
        }
        else
        {
            ResumeGame();
        }
    }

    public void OnAnswerSelected(int selectedIndex)
    {
        float responseTime = Time.time - startTime;
        bool isCorrect = selectedIndex == currentQuestion.correctAnswerIndex;

        if (isCorrect)
        {
            if (responseTime <= 10f)
            {
                nextQuestionDifficulty = Mathf.Min(3, nextQuestionDifficulty + 1);
            }
        }
        else
        {
            nextQuestionDifficulty = Mathf.Max(1, nextQuestionDifficulty - 1);
        }

        if (isCorrect)
        {
            correctAnswerPanel.SetActive(true);
            wrongAnswerPanel.SetActive(false);
            PlayerManage.totalMarks += 2;
        }
        else
        {
            wrongAnswerPanel.SetActive(true);
            correctAnswerPanel.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);

        Time.timeScale = 1;

        LoadQuestion();
    }
}
