using UnityEngine;
using TMPro;  // Import this if using TextMeshPro

public class EncouragementManager : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Assign in the Inspector
    public float messageDuration = 1f; // Time before message disappears

    private void Start()
    {
        messageText.text = ""; // Clear text initially
    }

    public void ShowMessage(bool isCorrect)
    {
        if (isCorrect)
        {
            string[] correctMessages = { "Good job!", "Well done!", "Great!", "Awesome!" };
            messageText.text = correctMessages[Random.Range(0, correctMessages.Length)];
        }
        else
        {
            string[] wrongMessages = { "Don't give up!", "Try again!", "You can!", "Keep going!" };
            messageText.text = wrongMessages[Random.Range(0, wrongMessages.Length)];
        }

        CancelInvoke("ClearMessage");
        Invoke("ClearMessage", messageDuration);
    }

    private void ClearMessage()
    {
        messageText.text = "";
    }
}

