using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Quiz : MonoBehaviour
{
    [System.Serializable]
    public class QuizQuestion
    {
        public string question;
        public string[] options;
        public string correctAnswer;
    }

    [Header("Tutorial Elements")]
    public GameObject tutorialPanel;
    public GameObject dragArrow;
    public GameObject dropArrow;
    public GameObject checkArrow;
    public float arrowAnimationSpeed = 2f;
    public float arrowMoveDistance = 50f;
    private bool tutorialShown = false;

    [Header("Quiz Elements")]
    public QuizQuestion[] questions;
    public Text[] optionTexts;
    public DropZone answerDropZone;
    public Button checkButton;
    
    [Header("Quiz Settings")]
    public int numberOfQuestionsToAsk = 20; 
    public bool preventRepeatQuestions = true; 

    [Header("UI Elements")]
    public AudioManager audioManager;
    public GameObject quizPanel;
    public GameObject scorePanel;
    public Text questionText;
    public Text scoreText;
    public Text feedbackText;
    public Button retryButton;
    public Button menuButton;

    [Header("Audio")]
    public AudioClip correctSound;
    public AudioClip wrongSound;

    private List<int> questionIndices = new List<int>(); 
    private int currentQuestionNumber = 0; 
    private int score = 0;
    private bool isProcessingAnswer = false;
    private AudioSource localAudioSource;

    PauseMenu pauseMenu;

    private void Awake()
    {
        
        localAudioSource = GetComponent<AudioSource>();
        if (localAudioSource == null)
        {
            localAudioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        
        if (audioManager == null)
        {
            audioManager = FindAnyObjectByType<AudioManager>();
            if (audioManager == null)
            {
                Debug.LogWarning("AudioManager not found in scene. Using local audio playback instead.");
            }
        }

        checkButton.onClick.AddListener(CheckAnswer);
        if (retryButton != null) retryButton.onClick.AddListener(Retry);
        if (menuButton != null) menuButton.onClick.AddListener(Levels);

        InitializeQuiz();
        ShowTutorial();
    }

    void ShowTutorial()
    {
        if (!tutorialShown && tutorialPanel != null)
        {
            tutorialPanel.SetActive(true);
            StartCoroutine(TutorialSequence());
        }
    }

    IEnumerator TutorialSequence()
    {
        
        if (dragArrow != null)
        {
            dragArrow.SetActive(true);
            if (dragArrow.GetComponent<RectTransform>() != null)
            {
                StartCoroutine(AnimateArrow(dragArrow.GetComponent<RectTransform>(), Vector2.right));
            }
            yield return new WaitForSeconds(3f);
        }

        
        if (dropArrow != null)
        {
            dragArrow.SetActive(false);
            dropArrow.SetActive(true);
            if (dropArrow.GetComponent<RectTransform>() != null)
            {
                StartCoroutine(AnimateArrow(dropArrow.GetComponent<RectTransform>(), Vector2.up));
            }
            yield return new WaitForSeconds(3f);
        }

        
        if (checkArrow != null)
        {
            dropArrow.SetActive(false);
            checkArrow.SetActive(true);
            if (checkArrow.GetComponent<RectTransform>() != null)
            {
                StartCoroutine(AnimateArrow(checkArrow.GetComponent<RectTransform>(), Vector2.left));
            }
            yield return new WaitForSeconds(3f);
        }

        
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
            if (dragArrow != null) dragArrow.SetActive(false);
            if (dropArrow != null) dropArrow.SetActive(false);
            if (checkArrow != null) checkArrow.SetActive(false);
        }

        tutorialShown = true;
    }

    IEnumerator AnimateArrow(RectTransform arrowRect, Vector2 direction)
    {
        if (arrowRect == null)
        {
            yield break;
        }
        
        Vector2 startPos = arrowRect.anchoredPosition;
        Vector2 endPos = startPos + (direction * arrowMoveDistance);

        while (arrowRect.gameObject.activeInHierarchy)
        {
            float t = (Mathf.Sin(Time.time * arrowAnimationSpeed) + 1) / 2;
            arrowRect.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }
    }

    void InitializeQuiz()
    {
        
        currentQuestionNumber = 0;
        score = 0;
        
        
        GenerateRandomQuestionSequence();
        
        
        DisplayQuestion();
        
        
        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false);
        }
        if (scorePanel != null)
        {
            scorePanel.SetActive(false);
        }
        if (quizPanel != null)
        {
            quizPanel.SetActive(true);
        }
    }
    
    void GenerateRandomQuestionSequence()
    {
        
        questionIndices.Clear();
        
        
        int questionsToUse = Mathf.Min(numberOfQuestionsToAsk, questions.Length);
        
        if (preventRepeatQuestions)
        {
            
            List<int> availableIndices = new List<int>();
            for (int i = 0; i < questions.Length; i++)
            {
                availableIndices.Add(i);
            }
            
            
            for (int i = 0; i < questionsToUse; i++)
            {
                if (availableIndices.Count == 0) break;
                
                int randomIndex = Random.Range(0, availableIndices.Count);
                questionIndices.Add(availableIndices[randomIndex]);
                availableIndices.RemoveAt(randomIndex);
            }
        }
        else
        {
            
            for (int i = 0; i < questionsToUse; i++)
            {
                questionIndices.Add(Random.Range(0, questions.Length));
            }
        }
        
        Debug.Log($"Generated random question sequence with {questionIndices.Count} questions");
    }

    void DisplayQuestion()
    {
        if (currentQuestionNumber < questionIndices.Count)
        {
            int questionIndex = questionIndices[currentQuestionNumber];
            QuizQuestion currentQuestion = questions[questionIndex];
            
            questionText.text = currentQuestion.question;

            for (int i = 0; i < optionTexts.Length; i++)
            {
                if (i < currentQuestion.options.Length)
                {
                    optionTexts[i].text = currentQuestion.options[i];
                }
            }
            
            Debug.Log($"Displaying question {currentQuestionNumber + 1}/{questionIndices.Count}: {currentQuestion.question}");
        }
    }

    public void CheckAnswer()
    {
        if (isProcessingAnswer) return;

        int currentQuestionIndex = questionIndices[currentQuestionNumber];
        string userAnswer = answerDropZone.GetCurrentLetter();
        Debug.Log($"User Answer: {userAnswer}, Correct Answer: {questions[currentQuestionIndex].correctAnswer}");

        if (string.IsNullOrEmpty(userAnswer))
        {
            ShowFeedback("Drag a letter to the box!", Color.yellow);
            return;
        }

        isProcessingAnswer = true;

        if (userAnswer.ToLower() == questions[currentQuestionIndex].correctAnswer.ToLower())
        {
            PlayCorrectSound();
            ShowFeedback("Correct!", Color.green);
            score++;
        }
        else
        {
            PlayWrongSound();
            ShowFeedback("Wrong!", Color.red);
        }

        StartCoroutine(NextQuestionDelay());
    }

    void PlayCorrectSound()
    {
        bool soundPlayed = false;

        
        if (audioManager != null)
        {
            if (audioManager.correct != null)
            {
                audioManager.PlaySFX(audioManager.correct);
                soundPlayed = true;
            }
            else if (correctSound != null)
            {
                audioManager.PlaySFX(correctSound);
                soundPlayed = true;
            }
        }

        
        if (!soundPlayed && correctSound != null)
        {
            if (localAudioSource != null)
            {
                localAudioSource.PlayOneShot(correctSound);
                soundPlayed = true;
            }
            else
            {
                AudioSource.PlayClipAtPoint(correctSound, Camera.main.transform.position);
                soundPlayed = true;
            }
        }
    }

    void PlayWrongSound()
    {
        bool soundPlayed = false;

        
        if (audioManager != null)
        {
            if (audioManager.wrong != null)
            {
                audioManager.PlaySFX(audioManager.wrong);
                soundPlayed = true;
            }
            else if (wrongSound != null)
            {
                audioManager.PlaySFX(wrongSound);
                soundPlayed = true;
            }
        }

        
        if (!soundPlayed && wrongSound != null)
        {
            if (localAudioSource != null)
            {
                localAudioSource.PlayOneShot(wrongSound);
                soundPlayed = true;
            }
            else
            {
                AudioSource.PlayClipAtPoint(wrongSound, Camera.main.transform.position);
                soundPlayed = true;
            }
        }
    }

    void ShowFeedback(string message, Color color)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.color = color;
            feedbackText.gameObject.SetActive(true);
        }
    }

    IEnumerator NextQuestionDelay()
    {
        yield return new WaitForSeconds(1f);

        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false);
        }

        NextQuestion();
        isProcessingAnswer = false;
    }

    void NextQuestion()
    {
        currentQuestionNumber++;
        if (currentQuestionNumber >= questionIndices.Count)
        {
            ShowScore();
        }
        else
        {
            answerDropZone.ClearDropZone();
            DisplayQuestion();
        }
    }

    void ShowScore()
    {
        if (quizPanel != null)
        {
            quizPanel.SetActive(false);
        }
        if (scorePanel != null)
        {
            scorePanel.SetActive(true);
        }
        if (scoreText != null)
        {
            scoreText.text = $"{score}/{questionIndices.Count}";
        }
    }

    public void Retry()
    {
        answerDropZone.ClearDropZone();
        InitializeQuiz();
    }

    public void Levels()
    {
        if (SceneUtility.GetBuildIndexByScenePath("Syllabus") >= 0)
        {
            SceneManager.LoadScene("Syllabus");
        }
        else
        {
            Debug.LogError("Scene 'Syllabus' is not in the build settings.");
            if (SceneManager.sceneCountInBuildSettings > 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
