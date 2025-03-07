using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    private Button button;
    private Color originalColor;

    void Start()
    {
        button = GetComponent<Button>();
        originalColor = button.colors.normalColor;
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            SetButtonColor(Color.green);
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            SetButtonColor(Color.red);
            quizManager.wrong();
        }
    }

    private void SetButtonColor(Color color)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = color;
        cb.selectedColor = color;
        button.colors = cb;
    }

    public void ResetButtonColor()
    {
        ColorBlock cb = button.colors;
        cb.normalColor = originalColor;
        cb.selectedColor = originalColor;
        button.colors = cb;
    }
}
