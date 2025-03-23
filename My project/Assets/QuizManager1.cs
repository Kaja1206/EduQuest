using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager1 : MonoBehaviour
{
    public List<QuestionsAnswers> easyQuestions;
    public List<QuestionsAnswers> mediumQuestions;
    public List<QuestionsAnswers> hardQuestions;

    private List<QuestionsAnswers> currentQuestionPool;
    private List<QuestionsAnswers> usedQuestions = new List<QuestionsAnswers>();

    public GameObject[] options;
    public GameObject QuizPanel;
    public GameObject GoPanel;
    public TMP_Text QuestionTxt;
    public Image QuestionImage; // Assuming you want to display the question image
    public Text ScoreTxt;

    private int questionCount = 0;  // Track number of questions asked
    public int score = 0;
    private const int maxQuestions = 5;  // Limit total questions

    private void Start()
    {
        currentQuestionPool = easyQuestions;  // Start with easy questions
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + maxQuestions;
    }

    public void Correct()
    {
        score += 1;
        AdjustDifficulty(true);
        StartCoroutine(WaitForNext());
    }

    public void Wrong()
    {
        AdjustDifficulty(false);
        StartCoroutine(WaitForNext());
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1); // Wait for 1 second before showing the next question
        generateQuestion(); // Call to generate the next question
    }

    private void SetAnswer(QuestionsAnswers selectedQuestion)
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript1>().startColor;
            options[i].GetComponent<AnswerScript1>().isCorrect = false;

            // Set answer text correctly
            options[i].transform.GetChild(0).GetComponent<Text>().text = selectedQuestion.Answers[i];

            // Mark correct answer
            if (selectedQuestion.CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript1>().isCorrect = true;
            }
        }
    }

    private void generateQuestion()
    {
        if (questionCount >= maxQuestions)
        {
            GameOver();
            return;
        }

        // Check if there are remaining questions in the current pool
        if (currentQuestionPool.Count > 0)
        {
            // Pick a random question and remove it from the pool
            int randomIndex = Random.Range(0, currentQuestionPool.Count);
            QuestionsAnswers selectedQuestion = currentQuestionPool[randomIndex];
            currentQuestionPool.RemoveAt(randomIndex);

            usedQuestions.Add(selectedQuestion);  // Store the used question
            QuestionTxt.text = selectedQuestion.Question;
            QuestionImage.sprite = selectedQuestion.QuestionImage; // Display question image

            SetAnswer(selectedQuestion);  // Pass the correct question

            questionCount++;  // Increment question count
        }
        else
        {
            GameOver(); // If there are no questions left, end the game
        }
    }

    private void AdjustDifficulty(bool isCorrect)
    {
        if (isCorrect)
        {
            // Adjust difficulty logic
            if (currentQuestionPool == easyQuestions)
            {
                currentQuestionPool = mediumQuestions; // Move to Medium
            }
            else if (currentQuestionPool == mediumQuestions)
            {
                currentQuestionPool = hardQuestions; // Move to Hard
            }
            // If already in Hard, stay in Hard
        }
        else
        {
            // Adjust difficulty logic when the answer is wrong
            if (currentQuestionPool == hardQuestions)
            {
                currentQuestionPool = mediumQuestions; // Move to Medium (Not Easy!)
            }
            else if (currentQuestionPool == mediumQuestions)
            {
                currentQuestionPool = easyQuestions; // Move to Easy
            }
            // If already in Easy, stay in Easy
        }
    }
}

