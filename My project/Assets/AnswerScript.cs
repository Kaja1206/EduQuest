using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Color startColor;

    private void Start()
    {
        Image image = GetComponent<Image>();
        if (image != null)
        {
            startColor = image.color;
        }
        else
        {
            Debug.LogError("Image component not found on " + gameObject.name);
        }
    }

    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.Correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.Wrong();
        }
    }
}