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
        audioSource.clip = background;
        audioSource.Play();

        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 1f);
        SetVolume(savedVolume);

        
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

        
        PlayerPrefs.SetFloat("GameVolume", volume);
        PlayerPrefs.Save();

        Debug.Log("Volume set to: " + volume);
    }

    
    public void UpdateVolumeSlider()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("GameVolume", 1f);
        }
    }
}





