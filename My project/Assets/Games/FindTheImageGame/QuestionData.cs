using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[System.Serializable] // Allows this class to be serialized and displayed in the Unity Inspector
public class Question
{
    public string questionText; // The text of the question
    public string[] replies; // Array of possible answers
    public int correctReplyIndex; // Index of the correct answer in the replies array
    public Sprite questionImage; // Optional image associated with the question
}

[CreateAssetMenu(fileName = "New Category", menuName ="FindTheImage")]
public class QuestionData : ScriptableObject
{
    public string category; // Name of the category
    public Question[] questions; // Array of questions belonging to this category
}
