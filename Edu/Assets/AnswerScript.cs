using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool iscorrect = false;
    public void Answer()
    {
        if (iscorrect)
        {
            Debug.Log("Correct Answer");
        }
        else
        {
            Debug.Log("Wrong Answer");
        }
    }
}
