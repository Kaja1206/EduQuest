using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text feedbackText;

    int totalQuestions = 0;
    public int score;

    public float delayBetweenQuestions = 0.5f;
    public float feedbackDisplayTime = 0.5f;
    public float feedbackAnimationDuration = 0.5f;

    private string[] correctFeedbacks = new string[] { "Wow!", "Perfect!", "Correct!", "Excellent!", "Great job!" };

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        totalQuestions = QnA.Count;
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

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void correct()
    {
        audioManager.PlaySFX(audioManager.correct);
        score += 1;
        ShowFeedback(correctFeedbacks[Random.Range(0, correctFeedbacks.Length)], Color.green);
        StartCoroutine(DelayedNextQuestion());
    }

    public void wrong()
    {
        audioManager.PlaySFX(audioManager.wrong);
        ShowFeedback("Try Again!", Color.red);
        StartCoroutine(DelayedNextQuestion());
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

        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            AnswerScript answerScript = options[i].GetComponent<AnswerScript>();
            answerScript.isCorrect = false;
            answerScript.quizManager = this;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                answerScript.isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}





