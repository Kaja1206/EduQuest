using UnityEngine;
using UnityEngine.UI;

public class VolumeUpdater : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        if (AudioManager.instance != null)
        {
            // Set the slider's value to the current volume
            float currentVolume = PlayerPrefs.GetFloat("GameVolume", 1f);
            volumeSlider.value = currentVolume;

            // Add listener to update AudioManager when slider value changes
            volumeSlider.onValueChanged.AddListener(AudioManager.instance.SetVolume);
        }
        else
        {
            Debug.LogError("AudioManager instance not found!");
        }
    }
}


