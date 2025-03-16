using UnityEngine;
using UnityEngine.UI;

public class VolumeUpdater : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        if (AudioManager.instance != null)
        {
            float currentVolume = PlayerPrefs.GetFloat("GameVolume", 1f);
            volumeSlider.value = currentVolume;

            volumeSlider.onValueChanged.AddListener(AudioManager.instance.SetVolume);
        }
        else
        {
            Debug.LogError("AudioManager instance not found!");
        }
    }
}


