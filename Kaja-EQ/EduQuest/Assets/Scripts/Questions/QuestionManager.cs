using UnityEngine;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour
{
    public List<Question> questions; // List of all questions

    private List<Question> availableQuestions; // Questions that haven't been used yet

    private void Awake()
    {
        // Initialize the list of available questions
        availableQuestions = new List<Question>(questions);
    }

    public Question GetQuestionByDifficulty(int difficulty)
    {
        // Filter available questions by difficulty
        List<Question> filteredQuestions = availableQuestions.FindAll(q => q.difficulty == difficulty);

        if (filteredQuestions.Count > 0)
        {
            // Get a random question from the filtered list
            int randomIndex = Random.Range(0, filteredQuestions.Count);
            Question randomQuestion = filteredQuestions[randomIndex];

            // Remove the question from the available list
            availableQuestions.Remove(randomQuestion);

            return randomQuestion;
        }

        // If no questions of the specified difficulty are found, return a random question
        return GetRandomQuestion();
    }

    public Question GetRandomQuestion()
    {
        if (availableQuestions.Count == 0)
        {
            // Refill the available questions list
            availableQuestions = new List<Question>(questions);
        }

        if (availableQuestions.Count > 0)
        {
            // Get a random question from the available questions
            int randomIndex = Random.Range(0, availableQuestions.Count);
            Question randomQuestion = availableQuestions[randomIndex];

            // Remove the question from the available list
            availableQuestions.RemoveAt(randomIndex);

            return randomQuestion;
        }

        // If no questions are left, return null
        return null;
    }
}
