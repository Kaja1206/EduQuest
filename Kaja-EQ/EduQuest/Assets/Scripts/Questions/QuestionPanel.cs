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
    private int nextQuestionDifficulty = 1; // Default difficulty for the next question

    private void Start()
    {
        // Hide panels initially
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);

        // Add listeners to the resume buttons
        correctResumeButton.onClick.AddListener(ResumeGame);
        wrongResumeButton.onClick.AddListener(ResumeGame);
    }

    private void OnEnable()
    {
        // Load a question when the panel is enabled
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        if (questionManager == null)
        {
            Debug.LogError("QuestionManager is not assigned!");
            return;
        }

        // Get a question based on the current difficulty
        currentQuestion = questionManager.GetQuestionByDifficulty(nextQuestionDifficulty);

        if (currentQuestion != null)
        {
            // Display the question text
            questionText.text = currentQuestion.questionText;

            // Display the answers on the buttons
            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < currentQuestion.answers.Length)
                {
                    answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[i];
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false); // Hide unused buttons
                }
            }

            // Start the timer
            startTime = Time.time;
        }
        else
        {
            Debug.LogWarning("No question available!");
        }
    }

    public void OnAnswerSelected(int selectedIndex)
    {
        // Calculate the response time
        float responseTime = Time.time - startTime;

        if (selectedIndex == currentQuestion.correctAnswerIndex)
        {
            // Correct answer
            correctAnswerPanel.SetActive(true);
            wrongAnswerPanel.SetActive(false);

            // Determine the difficulty of the next question based on response time
            if (responseTime <= 10f)
            {
                // Player answered quickly, increase difficulty
                nextQuestionDifficulty = Mathf.Min(3, nextQuestionDifficulty + 1); // Cap at 3 (hard)
            }
            else
            {
                // Player answered slowly, keep difficulty same or decrease
                nextQuestionDifficulty = Mathf.Clamp(nextQuestionDifficulty, 1, 3); // Ensure within 1 to 3
            }
        }
        else
        {
            // Wrong answer
            wrongAnswerPanel.SetActive(true);
            correctAnswerPanel.SetActive(false);

            // Decrease difficulty for the next question
            nextQuestionDifficulty = Mathf.Max(1, nextQuestionDifficulty - 1); // Ensure it doesn't go below 1 (easy)
        }
    }

    public void ResumeGame()
    {
        // Hide the question panel and feedback panels
        gameObject.SetActive(false);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);

        // Resume the game
        Time.timeScale = 1;
    }
}
