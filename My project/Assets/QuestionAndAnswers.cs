using UnityEngine;

[System.Serializable]
public class QuestionsAnswers
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;
    public Sprite QuestionImage; // Field for the question image
    public Sprite QuestionSprite { get; set; }
}




