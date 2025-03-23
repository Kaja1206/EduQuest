using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubQuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject SubQuizPanel;
    public GameObject GOPanel;

    public GameObject FeedbackPanel;
    public Text FeedbackText;
    public float feedbackDisplayTime = 2f;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GOPanel.SetActive(false);
        FeedbackPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        SubQuizPanel.SetActive(false);
        GOPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void Correct()
    {
        score += 1;
        ShowFeedback("Well done!", Color.green);
    }

    public void Wrong()
    {
        ShowFeedback("Oh, That's incorrect", Color.red);
    }

    void ShowFeedback(string message, Color color)
    {
        FeedbackText.text = message;
        FeedbackText.color = color;
        FeedbackPanel.SetActive(true);
        StartCoroutine(HideFeedbackAndnext());
    }

    IEnumerator HideFeedbackAndnext()
    {
        yield return new WaitForSeconds(feedbackDisplayTime);
        FeedbackPanel.SetActive(false);

        if (QnA.Count > 0)
        {
            QnA.RemoveAt(currentQuestion);
            if (currentQuestion >= QnA.Count && QnA.Count > 0)
            {
                currentQuestion = QnA.Count - 1;
            }
            generateQuestion();
        }
        else
        {
            GameOver();
        }
    }

    void SetAnswer()
    {
        if (QnA.Count == 0)
        {
            GameOver();
            return;
        }

        if (QnA[currentQuestion].Answers.Length != options.Length)
        {
            Debug.LogError("Mismatch between answer choices and UI options. Check your data!");
            return;
        }

        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript1>().startColor; // Corrected here
        }

        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript1>().isCorrect = false; // Corrected here
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript1>().isCorrect = true; // Corrected here
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            ResetButtonColors();
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("No more questions available.");
            GameOver();
        }
    }

    void ResetButtonColors()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript1>().startColor; // Corrected here
        }
    }
}