using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
        }
        else
        {
            Debug.Log("Wrong Answer");
        }

        quizManager.correct(); // Calls correct() to move to the next question
    }
}

