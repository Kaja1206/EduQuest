using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript1 : MonoBehaviour
{
    public bool isCorrect = false;
    private EncouragementManager encouragementManager;
    public QuizManager1 quizManager1;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
        encouragementManager = FindFirstObjectByType<EncouragementManager>();
    }

    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            audioManager.PlaySFX(audioManager.correct);
            Debug.Log("Correct Answer");
            encouragementManager.ShowMessage(true);
            quizManager1.Correct(); // Call Correct method from QuizManager
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            audioManager.PlaySFX(audioManager.wrong);
            Debug.Log("Wrong Answer");
            encouragementManager.ShowMessage(false);
            quizManager1.Wrong(); // Call Wrong method from QuizManager
        }
    }
}
