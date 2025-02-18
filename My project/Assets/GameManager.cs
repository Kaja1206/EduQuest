using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty currentDifficulty = Difficulty.Medium;

    private int correctAnswers = 0;
    private int incorrectAnswers = 0;
    private float questionStartTime;
    private float timeTaken;

    private float fastThreshold = 3f;  // Fast if answered within 3 seconds
    private float slowThreshold = 8f;  // Slow if taking more than 8 seconds

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start the timer when a question is displayed
    public void StartQuestionTimer()
    {
        questionStartTime = Time.time;
    }

    // Called when the player selects an answer
    public void CheckAnswer(bool isCorrect)
    {
        timeTaken = Time.time - questionStartTime; // Calculate time taken

        if (isCorrect)
        {
            correctAnswers++;
            incorrectAnswers = 0; // Reset incorrect streak
            AdjustDifficulty(true);
        }
        else
        {
            incorrectAnswers++;
            AdjustDifficulty(false);
        }

        // Load the next question
        if (QuizManager.instance != null)
        {
            QuizManager.instance.generateQuestion();
        }
        else
        {
            Debug.LogError("QuizManager instance is NULL! Ensure it's added to the scene.");
        }
    }

    // Adjust difficulty based on performance
    private void AdjustDifficulty(bool answeredCorrectly)
    {
        if (answeredCorrectly && timeTaken <= fastThreshold)
        {
            IncreaseDifficulty();
        }
        else if (!answeredCorrectly && timeTaken >= slowThreshold)
        {
            DecreaseDifficulty();
        }
    }

    private void IncreaseDifficulty()
    {
        if (currentDifficulty == Difficulty.Easy)
            currentDifficulty = Difficulty.Medium;
        else if (currentDifficulty == Difficulty.Medium)
            currentDifficulty = Difficulty.Hard;
    }

    private void DecreaseDifficulty()
    {
        if (currentDifficulty == Difficulty.Hard)
            currentDifficulty = Difficulty.Medium;
        else if (currentDifficulty == Difficulty.Medium)
            currentDifficulty = Difficulty.Easy;
    }
}



