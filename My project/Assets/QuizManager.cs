using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt; // FIXED: Changed from TextAlignment to Text

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        if (QnA.Count > 0) // Prevents error if list is empty
        {
            QnA.RemoveAt(currentQuestion);
            generateQuestion();
        }
        else
        {
            Debug.Log("No more questions available.");
        }
    }

    void SetAnswer()
    {
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
        if (QnA.Count > 0) // Prevents selecting from an empty list
         {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("No more questions available.");
        }
    }


}

