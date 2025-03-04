using System;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string questionText; // The question to display
    public string[] answers;    // Array of possible answers (4 options)
    public int correctAnswerIndex; // Index of the correct answer (0 to 3)
    public int difficulty; // Difficulty level (e.g., 1 = easy, 2 = medium, 3 = hard)
}