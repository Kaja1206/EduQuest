using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    private int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    private int totalQuestions = 0;
    private int score = 0;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void Correct()
    {
        score++;
        RemoveCurrentQuestion();
    }

    public void Wrong()
    {
        StartCoroutine(WaitForNext());
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        RemoveCurrentQuestion();
    }

    private void RemoveCurrentQuestion()
    {
        if (QnA.Count > 0)
        {
            QnA.RemoveAt(currentQuestion);
        }

        if (QnA.Count > 0)
        {
            generateQuestion();
        }
        else
        {
            GameOver();
        }
    }

    private void SetAnswer()
    {
        if (QnA.Count == 0)
        {
            GameOver();
            return;
        }

        if (QnA[currentQuestion].Answers.Length < options.Length)
        {
            Debug.LogError("Not enough answers provided for the available UI options. Check your data!");
            return;
        }

        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    private void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            GameOver();
        }
    }
}
