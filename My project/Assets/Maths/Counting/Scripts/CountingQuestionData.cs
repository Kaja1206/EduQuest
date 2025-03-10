using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{
    public string questionText;
    public string[] replies;
    public int correctReplyIndex;
    public Sprite questionImage;
}

[CreateAssetMenu(fileName = "New Category", menuName = "Quiz/Question Data")]
public class CountingQuestionData : ScriptableObject
{
    public string category;
    public Question[] questions;
}