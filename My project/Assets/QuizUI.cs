using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager1 quizManager; // Fix: Renamed to match the manager script
    [SerializeField] private Text QuestionText;
    [SerializeField] private Image QuestionImage;
    [SerializeField] private UnityEngine.Video.VideoPlayer QuestionVideo;
    [SerializeField] private AudioSource QuestionAudio;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctCol, wrongCol, normalCol;

    private Question question;
    private bool answered;
    private float audioLength;

    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    public void SetQuestion(Question question)
    {
        this.question = question;
        ImageHolder(); // Ensure only the needed UI elements are active

        switch (question.questionType)
        {
            case QuestionType.TEXT:
                QuestionImage.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                QuestionImage.gameObject.SetActive(true);
                QuestionImage.sprite = question.questionImg;
                break;
            case QuestionType.VIDEO:
                QuestionVideo.gameObject.SetActive(true);
                QuestionVideo.clip = question.questionVideo;
                QuestionVideo.Play();
                break;
            case QuestionType.AUDIO:
                QuestionAudio.gameObject.SetActive(true);
                audioLength = question.questionClip.length;
                StartCoroutine(PlayAudio());
                break;
        }

        QuestionText.text = question.questionInfo;

        List<string> answerList = ShuffleList.ShuffleListItems(question.options);
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalCol;
        }

        answered = false;
    }

    IEnumerator PlayAudio()
    {
        if (question.questionType == QuestionType.AUDIO)
        {
            QuestionAudio.PlayOneShot(question.questionClip);
            yield return new WaitForSeconds(audioLength + 0.5f);
        }
    }

    void ImageHolder()
    {
        // Ensure only the needed UI elements are active
        QuestionImage.gameObject.SetActive(false);
        QuestionVideo.gameObject.SetActive(false);
        QuestionAudio.gameObject.SetActive(false);
    }

    private void OnClick(Button btn)
    {
        if (!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if (val)
            {
                btn.image.color = correctCol;
            }
            else
            {
                btn.image.color = wrongCol;
            }
        }
    }
}



