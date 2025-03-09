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

    [Header("Tutorial Elements")]
    public GameObject tutorialPanel;
    public GameObject dragArrow;
    public GameObject dropArrow;
    public GameObject checkArrow;
    public float arrowAnimationSpeed = 2f;
    public float arrowMoveDistance = 50f;
    private bool tutorialShown = false;

    [Header("Quiz Elements")]
    public QuizQuestion[] questions;
    public Text[] optionTexts;
    public DropZone answerDropZone;
    public Button checkButton;

    [Header("UI Elements")]
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
        ShowTutorial();
    }

    void ShowTutorial()
    {
        if (!tutorialShown && tutorialPanel != null)
        {
            tutorialPanel.SetActive(true);
            StartCoroutine(TutorialSequence());
        }
    }

    IEnumerator TutorialSequence()
    {
        // Show drag arrow first
        if (dragArrow != null)
        {
            dragArrow.SetActive(true);
            StartCoroutine(AnimateArrow(dragArrow.GetComponent<RectTransform>(), Vector2.right));
            yield return new WaitForSeconds(3f);
        }

        // Show drop arrow next
        if (dropArrow != null)
        {
            dragArrow.SetActive(false);
            dropArrow.SetActive(true);
            StartCoroutine(AnimateArrow(dropArrow.GetComponent<RectTransform>(), Vector2.up));
            yield return new WaitForSeconds(3f);
        }

        // Show check arrow last
        if (checkArrow != null)
        {
            dropArrow.SetActive(false);
            checkArrow.SetActive(true);
            StartCoroutine(AnimateArrow(checkArrow.GetComponent<RectTransform>(), Vector2.left));
            yield return new WaitForSeconds(3f);
        }

        // Hide tutorial
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
            if (dragArrow != null) dragArrow.SetActive(false);
            if (dropArrow != null) dropArrow.SetActive(false);
            if (checkArrow != null) checkArrow.SetActive(false);
        }

        tutorialShown = true;
    }

    IEnumerator AnimateArrow(RectTransform arrowRect, Vector2 direction)
    {
        Vector2 startPos = arrowRect.anchoredPosition;
        Vector2 endPos = startPos + (direction * arrowMoveDistance);

        while (arrowRect.gameObject.activeInHierarchy)
        {
            float t = (Mathf.Sin(Time.time * arrowAnimationSpeed) + 1) / 2;
            arrowRect.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }
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