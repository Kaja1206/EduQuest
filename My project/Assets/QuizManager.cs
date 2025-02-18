using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance; // Singleton instance

    public enum DifficultyLevel { Easy, Medium, Hard }
    public DifficultyLevel currentDifficulty = DifficultyLevel.Medium;

    public List<QuestionsAnswers> easyQnA;
    public List<QuestionsAnswers> mediumQnA;
    public List<QuestionsAnswers> hardQnA;

    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;
    public Text QuestionTxt;
    public Text ScoreTxt;

    private int totalQuestions = 0;
    public int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Check if required GameObjects are assigned
        if (GoPanel == null) Debug.LogError("GoPanel is not assigned in the Inspector!");
        if (QuestionTxt == null) Debug.LogError("QuestionTxt is not assigned in the Inspector!");
        if (ScoreTxt == null) Debug.LogError("ScoreTxt is not assigned in the Inspector!");

        totalQuestions = (easyQnA?.Count ?? 0) + (mediumQnA?.Count ?? 0) + (hardQnA?.Count ?? 0);
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        if (Quizpanel != null) Quizpanel.SetActive(false);
        if (GoPanel != null) GoPanel.SetActive(true);

        if (ScoreTxt != null)
            ScoreTxt.text = score + "/" + totalQuestions;
        else
            Debug.LogError("ScoreTxt is not assigned in the Inspector!");
    }

    public void Correct()
    {
        score += 1;
        if (GameManager.instance != null)
        {
            GameManager.instance.CheckAnswer(true);
        }
        else
        {
            Debug.LogError("GameManager instance is NULL! Ensure it's in the scene.");
        }
        RemoveCurrentQuestion();
        StartCoroutine(WaitForNext());
    }

    public void Wrong()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.CheckAnswer(false);  // Fixed: Passing false for incorrect answers
        }
        else
        {
            Debug.LogError("GameManager instance is NULL! Ensure it's in the scene.");
        }
        RemoveCurrentQuestion();
        StartCoroutine(WaitForNext());
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    void RemoveCurrentQuestion()
    {
        List<QuestionsAnswers> questionPool = GetQuestionPool();
        if (questionPool.Count > 0)
        {
            questionPool.RemoveAt(currentQuestion);
        }

        if (questionPool.Count > 0)
        {
            generateQuestion();
        }
        else
        {
            GameOver();
        }
    }

    void SetAnswer()
    {
        List<QuestionsAnswers> questionPool = GetQuestionPool();
        if (questionPool == null || questionPool.Count == 0)
        {
            Debug.LogError("No questions available! Ensure that questions are added.");
            GameOver();
            return;
        }

        if (questionPool[currentQuestion].Answers.Length != options.Length)
        {
            Debug.LogError("Mismatch between answer choices and UI options. Check your data!");
            return;
        }

        for (int i = 0; i < options.Length; i++)
        {
            if (options[i] == null)
            {
                Debug.LogError($"Option {i} is null! Assign it in the Inspector.");
                continue;
            }

            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = questionPool[currentQuestion].Answers[i];

            if (questionPool[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void generateQuestion()
    {
        List<QuestionsAnswers> questionPool = GetQuestionPool();

        if (questionPool == null || questionPool.Count == 0)
        {
            Debug.LogError("No more questions available.");
            GameOver();
            return;
        }

        currentQuestion = Random.Range(0, questionPool.Count);
        if (QuestionTxt != null)
            QuestionTxt.text = questionPool[currentQuestion].Question;
        else
            Debug.LogError("QuestionTxt is null! Assign it in the Inspector.");

        SetAnswer();

        if (GameManager.instance != null)
        {
            GameManager.instance.StartQuestionTimer();
        }
        else
        {
            Debug.LogError("GameManager instance is NULL! Ensure it's in the scene.");
        }
    }

    private List<QuestionsAnswers> GetQuestionPool()
    {
        switch (currentDifficulty)
        {
            case DifficultyLevel.Easy: return easyQnA ?? new List<QuestionsAnswers>();
            case DifficultyLevel.Medium: return mediumQnA ?? new List<QuestionsAnswers>();
            case DifficultyLevel.Hard: return hardQnA ?? new List<QuestionsAnswers>();
            default: return mediumQnA ?? new List<QuestionsAnswers>();
        }
    }
}




