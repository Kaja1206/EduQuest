using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    [Header("Question Pools")]
    public List<QuestionAndAnswers> easyQuestions;
    public List<QuestionAndAnswers> mediumQuestions;
    public List<QuestionAndAnswers> hardQuestions;

    [Header("UI Elements")]
    public GameObject[] options;
    public GameObject QuizPanel;
    public GameObject GoPanel;
    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text feedbackText;
    public Text difficultyText; 
    public Text timerText; 

    [Header("Quiz Settings")]
    public int maxQuestions = 10;
    public int score = 0;
    public float delayBetweenQuestions = 0.5f;
    public float feedbackDisplayTime = 0.5f;
    public float feedbackAnimationDuration = 0.5f;
    public float timeThreshold = 10f; 

    private List<QuestionAndAnswers> currentQuestionPool;
    private List<QuestionAndAnswers> usedQuestions = new List<QuestionAndAnswers>();
    private int questionCount = 0;
    private float questionStartTime;
    private string[] correctFeedbacks = new string[] { "Wow!", "Perfect!", "Correct!", "Excellent!", "Great job!" };

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio")?.GetComponent<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogWarning("AudioManager not found. Make sure it's tagged correctly.");
        }
    }

    private void Start()
    {
        currentQuestionPool = easyQuestions; 
        GoPanel.SetActive(false);
        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false);
        }
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Levels()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void Level()
    {
        SceneManager.LoadScene("Syllabus");
    }


    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + maxQuestions;
    }

    public void correct()
    {
        if (audioManager != null) audioManager.PlaySFX(audioManager.correct);
        score += 1;

        
        AdjustDifficulty(true);

        ShowFeedback(correctFeedbacks[Random.Range(0, correctFeedbacks.Length)], Color.green);
        StartCoroutine(DelayedNextQuestion());
    }

    public void wrong()
    {
        if (audioManager != null) audioManager.PlaySFX(audioManager.wrong);

        
        AdjustDifficulty(false);

        ShowFeedback("Wrong!", Color.red);
        StartCoroutine(DelayedNextQuestion());
    }

    private void AdjustDifficulty(bool isCorrect)
    {
        float timeTaken = Time.time - questionStartTime;
        bool isFast = timeTaken <= timeThreshold;

        string currentDifficulty = "Easy";
        if (currentQuestionPool == mediumQuestions) currentDifficulty = "Medium";
        if (currentQuestionPool == hardQuestions) currentDifficulty = "Hard";

        string nextDifficulty = currentDifficulty; 

        
        if (currentQuestionPool == easyQuestions) 
        {
            if (isCorrect && isFast)
            {
                nextDifficulty = "Medium";
                currentQuestionPool = mediumQuestions;
            }
            else
            {
                nextDifficulty = "Easy";
                currentQuestionPool = easyQuestions;
            }
        }
        else if (currentQuestionPool == mediumQuestions) 
        {
            if (isCorrect && isFast)
            {
                nextDifficulty = "Hard";
                currentQuestionPool = hardQuestions;
            }
            else
            {
               
                nextDifficulty = "Easy";
                currentQuestionPool = easyQuestions;
            }
        }
        else if (currentQuestionPool == hardQuestions) 
        {
            if (isCorrect && isFast)
            {
                nextDifficulty = "Hard";
                currentQuestionPool = hardQuestions;
            }
            else
            {
                nextDifficulty = "Medium";
                currentQuestionPool = mediumQuestions;
            }
        }

        
        Debug.Log($"Answer: {(isCorrect ? "Correct" : "Incorrect")}, Time: {timeTaken:F1}s ({(isFast ? "Fast" : "Slow")}), " +
                  $"Difficulty change: {currentDifficulty} ? {nextDifficulty}");

        
        if (difficultyText != null)
        {
            difficultyText.text = "Difficulty: " + nextDifficulty;
        }

        
        if (timerText != null)
        {
            timerText.text = $"Time: {timeTaken:F1}s";
        }
    }

    private void ShowFeedback(string message, Color color)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.color = color;
            feedbackText.gameObject.SetActive(true);
            StartCoroutine(AnimateFeedback());
        }
    }

    private IEnumerator AnimateFeedback()
    {
        feedbackText.transform.localScale = Vector3.zero;
        float elapsedTime = 0f;

        while (elapsedTime < feedbackAnimationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / feedbackAnimationDuration;
            feedbackText.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.SmoothStep(0, 1, progress));
            yield return null;
        }

        feedbackText.transform.localScale = Vector3.one;

        yield return new WaitForSeconds(feedbackDisplayTime);

        elapsedTime = 0f;
        while (elapsedTime < feedbackAnimationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / feedbackAnimationDuration;
            feedbackText.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, Mathf.SmoothStep(0, 1, progress));
            yield return null;
        }

        feedbackText.gameObject.SetActive(false);
    }

    IEnumerator DelayedNextQuestion()
    {
        yield return new WaitForSeconds(delayBetweenQuestions + feedbackAnimationDuration + feedbackDisplayTime);

        foreach (GameObject option in options)
        {
            option.GetComponent<AnswerScript>().ResetButtonColor();
        }

        generateQuestion();
    }

    void SetAnswers(QuestionAndAnswers question)
    {
        for (int i = 0; i < options.Length; i++)
        {
            AnswerScript answerScript = options[i].GetComponent<AnswerScript>();
            answerScript.isCorrect = false;
            answerScript.quizManager = this;
            options[i].transform.GetChild(0).GetComponent<Text>().text = question.Answers[i];

            if (question.CorrectAnswer == i + 1)
            {
                answerScript.isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (questionCount >= maxQuestions)
        {
            GameOver();
            return;
        }

        if (currentQuestionPool.Count > 0)
        {
            questionStartTime = Time.time;

            QuestionAndAnswers selectedQuestion = currentQuestionPool[0];
            currentQuestionPool.RemoveAt(0);

            
            usedQuestions.Add(selectedQuestion);

            
            QuestionTxt.text = selectedQuestion.Question;
            SetAnswers(selectedQuestion);

            
            questionCount++;

            
            string difficultyName = "Easy";
            if (currentQuestionPool == mediumQuestions) difficultyName = "Medium";
            if (currentQuestionPool == hardQuestions) difficultyName = "Hard";

            Debug.Log($"Question {questionCount}/{maxQuestions}: {selectedQuestion.Question} (Difficulty: {difficultyName})");
        }
        else if (easyQuestions.Count > 0 || mediumQuestions.Count > 0 || hardQuestions.Count > 0)
        {
            
            if (currentQuestionPool == hardQuestions)
            {
                currentQuestionPool = mediumQuestions;
                Debug.Log("Hard question pool empty, switching to Medium");
            }
            else if (currentQuestionPool == mediumQuestions)
            {
                currentQuestionPool = easyQuestions;
                Debug.Log("Medium question pool empty, switching to Easy");
            }
            else if (currentQuestionPool == easyQuestions)
            {
                
                if (mediumQuestions.Count > 0)
                {
                    currentQuestionPool = mediumQuestions;
                    Debug.Log("Easy question pool empty, switching to Medium");
                }
                else if (hardQuestions.Count > 0)
                {
                    currentQuestionPool = hardQuestions;
                    Debug.Log("Easy and Medium question pools empty, switching to Hard");
                }
            }

            
            generateQuestion();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}
