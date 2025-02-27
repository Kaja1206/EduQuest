using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    private QuizManager quizManager;

    private void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();  // Ensures the reference is set automatically
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.Correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.Wrong();
        }
    }
}





