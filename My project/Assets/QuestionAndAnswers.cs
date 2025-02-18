using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionsAnswers
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;
    public QuizManager.DifficultyLevel difficultyLevel;
    // Correct reference to GameManager's Difficulty
}



