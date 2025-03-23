using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Array to hold different question categories
    public QuestionData[] categories;
    private QuestionData selectedCategory;
    private int currentQuestionIndex = 0;

    // UI Elements for displaying questions
    public TMP_Text questionText;
    public Image questionImage;
    public Button[] replyButtons;

    [Header("Score")]
    public ScoreManager score; // Reference to the score manager
    public int correctReply = 10; // Points for a correct answer
    public int wrongReply = 0; // Points deducted for a wrong answer
    public TextMeshProUGUI scoreText; // UI text to display score

    [Header("correctReplyIndex")]
    public int correctReplyIndex; // Stores the correct answer index
    int correctReplies; // Counter for correct answers

    [Header("Game Finished Panel")]
    public GameObject GameFinished; // UI Panel displayed when quiz is completed

    void Start()
    {
        // Get the selected category index from PlayerPrefs (default to 0)
        int selectedCategoryIndex = PlayerPrefs.GetInt("SelectedCategory", 0);

        // Hide the game finished panel initially
        GameFinished.SetActive(false);

        // Select the category based on saved index
        SelectedCategory(selectedCategoryIndex);

        // Load previous progress if available
        LoadProgress(selectedCategoryIndex);
    }

    // Selects a category based on the given index
    public void SelectedCategory(int categoryIndex)
    {
        selectedCategory = categories[categoryIndex]; // Assign selected category
        currentQuestionIndex = 0; // Reset question index
        DisplayQuestion(); // Display the first question
    }

    // Displays the current question and its possible replies
    public void DisplayQuestion()
    {
        if (selectedCategory == null) return; // If no category is selected, exit function

        ResetButtons(); // Reset button interactions

        var question = selectedCategory.questions[currentQuestionIndex]; // Get current question

        // Update UI elements with question data
        questionText.text = question.questionText;
        questionImage.sprite = question.questionImage;

        // Loop through reply buttons and set their text
        for (int i = 0; i < replyButtons.Length; i++)
        {
            TMP_Text buttonText = replyButtons[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = question.replies[i];
        }
    }

    // Called when a reply button is selected
    public void OnReplySelected(int replyIndex)
    {
        // Check if selected reply is correct
        if (replyIndex == selectedCategory.questions[currentQuestionIndex].correctReplyIndex)
        {
            score.AddScore(correctReply); // Add points for correct answer
            correctReplies++; // Increment correct answer counter
            Debug.Log("Correct Reply!");
        }
        else
        {
            score.SubtractScore(wrongReply); // Deduct points for wrong answer
            Debug.Log("Wrong Reply!");
        }

        currentQuestionIndex++; // Move to next question
        SaveProgress(); // Save progress

        // Check if more questions remain
        if (currentQuestionIndex < selectedCategory.questions.Length)
        {
            DisplayQuestion(); // Show next question
        }
        else
        {
            ShowGameFinishedPanel(); // Display game finished screen
            Debug.Log("Quiz Finished!");
        }
    }

    // Highlights the correct reply for the current question
    public void ShowCorrectReply()
    {
        correctReplyIndex = selectedCategory.questions[currentQuestionIndex].correctReplyIndex;

        for (int i = 0; i < replyButtons.Length; i++)
        {
            if (i == correctReplyIndex)
            {
                replyButtons[i].interactable = true;
            }
            else
            {
                replyButtons[i].interactable = false;
            }    
        }
    }

    // Resets reply button interactions to be clickable again
    public void ResetButtons()
    {
        foreach (var button in replyButtons)
        {
            button.interactable = true;
        }
    }

    // Displays the game finished panel with final score
    public void ShowGameFinishedPanel()
    {
        GameFinished.SetActive(true);
        scoreText.text = "" + correctReplies + "/" + selectedCategory.questions.Length;
    }

    // Saves the player's progress using PlayerPrefs
    private void SaveProgress()
    {
        PlayerPrefs.SetInt("LastQuestionIndex_" + selectedCategory.name, currentQuestionIndex);
        PlayerPrefs.Save();
    }

    // Loads the player's progress from PlayerPrefs
    private void LoadProgress(int categoryIndex)
    {
        string categoryName = categories[categoryIndex].name;
        currentQuestionIndex = PlayerPrefs.GetInt("LastQuestionIndex_" + categoryName, 0);

        DisplayQuestion(); // Load the saved question index
    }
}
