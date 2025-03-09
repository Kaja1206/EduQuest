using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DancingCharacter : MonoBehaviour
{
    public Sprite[] danceFrames;  // Assign your dance animation frames in the Inspector
    public float framesPerSecond = 12f;

    private Image characterImage;
    private int currentFrame;

    void Start()
    {
        characterImage = GetComponent<Image>();
        if (characterImage == null)
        {
            characterImage = gameObject.AddComponent<Image>();
        }

        if (danceFrames.Length > 0)
        {
            StartCoroutine(AnimateDance());
        }
        else
        {
            Debug.LogError("No dance frames assigned!");
        }
    }

    IEnumerator AnimateDance()
    {
        while (true)  // Loop forever
        {
            currentFrame = (currentFrame + 1) % danceFrames.Length;
            characterImage.sprite = danceFrames[currentFrame];

            yield return new WaitForSeconds(1f / framesPerSecond);
        }
    }
}
