using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }
    void SetAnswer()
    { 
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().iscorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;
    }
}
