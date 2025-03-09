using System;

[Serializable]
public class QuestionAndAnswers
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;
    public DifficultyLevel Difficulty;
}
public enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}
