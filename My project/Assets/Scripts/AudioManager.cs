using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip correct;
    public AudioClip wrong;

    [Header("---------- Volume Control ----------")]
    [SerializeField] Slider volumeSlider;

    private void Awake()
    {
        // Singleton pattern to ensure only one AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        InitializeAudio();
    }

    private void InitializeAudio()
    {
        // Set up background music
        audioSource.clip = background;
        audioSource.Play();

        // Load saved volume settings
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 1f);
        SetVolume(savedVolume);

        // Initialize volume slider
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            Debug.LogWarning("Volume slider not assigned to AudioManager!");
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        SFXSource.volume = volume;

        // Save volume for all scenes
        PlayerPrefs.SetFloat("GameVolume", volume);
        PlayerPrefs.Save();

        Debug.Log("Volume set to: " + volume);
    }

    // Call this method when entering a new scene
    public void UpdateVolumeSlider()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("GameVolume", 1f);
        }
    }
}





