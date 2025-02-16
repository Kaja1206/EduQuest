using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void Correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());

    }

    public void Wrong() 
    {
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

    void SetAnswer()
    {
        if (QnA.Count == 0)
        {
            GameOver();
            return;
        }

        // Prevent array index out of bounds error
        if (QnA[currentQuestion].Answers.Length != options.Length)
        {
            Debug.LogError("Mismatch between answer choices and UI options. Check your data!");
            return;
        }

        for (int i = 0; i < options.Length; i++)
        {
            
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
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
}

