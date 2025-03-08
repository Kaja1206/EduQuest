using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
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
    public Text ScoreTxt;

    private float questionStartTime;
    private int questionCount = 0;  // Track number of questions asked
    public int score = 0;
    private const int maxQuestions = 5;  // Limit total questions

    private void Start()
    {
        currentQuestionPool = easyQuestions;  // Start with easy
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
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    private void SetAnswer(QuestionsAnswers selectedQuestion)
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;

            // Set answer text correctly
            options[i].transform.GetChild(0).GetComponent<Text>().text = selectedQuestion.Answers[i];

            // Mark correct answer
            if (selectedQuestion.CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
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

        if (currentQuestionPool.Count > 0)
        {
            questionStartTime = Time.time;  // Start timing

            // Pick first question and remove it from pool
            QuestionsAnswers selectedQuestion = currentQuestionPool[0];
            currentQuestionPool.RemoveAt(0);

            usedQuestions.Add(selectedQuestion);  // Store used question
            QuestionTxt.text = selectedQuestion.Question;

            SetAnswer(selectedQuestion);  // Pass correct question

            questionCount++;  // Increment question count
        }
        else
        {
            GameOver();
        }
    }


    private void AdjustDifficulty(bool isCorrect)
    {
        float timeTaken = Time.time - questionStartTime; // Calculate response time
        bool isSlow = timeTaken > 10f; // Define slow response (10 seconds)

        if (isCorrect)
        {
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
        else if (!isCorrect || isSlow) // Check if the answer is incorrect OR slow
        {
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


