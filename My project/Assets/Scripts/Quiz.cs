using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    [System.Serializable]
    public class QuizQuestion
    {
        public string question;
        public string[] options;
        public string correctAnswer;
    }

    public QuizQuestion[] questions;
    public Text[] optionTexts;
    public DropZone answerDropZone;
    public Button checkButton;

    public AudioManager audioManager;
    public GameObject quizPanel;
    public GameObject scorePanel;

    public Text questionText;
    public Text scoreText;
    public Text feedbackText;

    public Button retryButton;
    public Button menuButton;

    private int currentQuestionIndex = 0;
    private int score = 0;
    private bool isProcessingAnswer = false;

    PauseMenu pauseMenu;

    private void Start()
    {
        checkButton.onClick.AddListener(CheckAnswer);
        if (retryButton != null) retryButton.onClick.AddListener(Retry);
        if (menuButton != null) menuButton.onClick.AddListener(ReturnToHome);

        InitializeQuiz();
    }

    void InitializeQuiz()
    {
        currentQuestionIndex = 0;
        score = 0;
        DisplayQuestion();
        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false);
        }
        if (scorePanel != null)
        {
            scorePanel.SetActive(false);
        }
        if (quizPanel != null)
        {
            quizPanel.SetActive(true);
        }
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            QuizQuestion currentQuestion = questions[currentQuestionIndex];
            questionText.text = currentQuestion.question;

            for (int i = 0; i < optionTexts.Length; i++)
            {
                if (i < currentQuestion.options.Length)
                {
                    optionTexts[i].text = currentQuestion.options[i];
                }
            }
        }
    }

    public void CheckAnswer()
    {
        if (isProcessingAnswer) return;

        string userAnswer = answerDropZone.GetCurrentLetter();
        Debug.Log($"User Answer: {userAnswer}, Correct Answer: {questions[currentQuestionIndex].correctAnswer}");

        if (string.IsNullOrEmpty(userAnswer))
        {
            ShowFeedback("Please drag a letter to the answer box!", Color.yellow);
            return;
        }

        isProcessingAnswer = true;

        if (userAnswer.ToLower() == questions[currentQuestionIndex].correctAnswer.ToLower())
        {
            if (audioManager != null) audioManager.PlaySFX(audioManager.correct);
            ShowFeedback("Correct!", Color.green);
            score++;
        }
        else
        {
            if (audioManager != null) audioManager.PlaySFX(audioManager.wrong);
            ShowFeedback("Wrong!", Color.red);
        }

        StartCoroutine(NextQuestionDelay());
    }

    void ShowFeedback(string message, Color color)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.color = color;
            feedbackText.gameObject.SetActive(true);
        }
    }

    IEnumerator NextQuestionDelay()
    {
        yield return new WaitForSeconds(1f);

        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false);
        }

        NextQuestion();
        isProcessingAnswer = false;
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex >= questions.Length)
        {
            ShowScore();
        }
        else
        {
            answerDropZone.ClearDropZone();
            DisplayQuestion();
        }
    }

    void ShowScore()
    {
        if (quizPanel != null)
        {
            quizPanel.SetActive(false);
        }
        if (scorePanel != null)
        {
            scorePanel.SetActive(true);
        }
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score} / {questions.Length}";
        }
    }

    public void Retry()
    {
        answerDropZone.ClearDropZone();
        InitializeQuiz();
    }

    public void ReturnToHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }
}