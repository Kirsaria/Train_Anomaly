using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public GameObject buttonAudio;
    public Slider sliderAudio;
    public AudioSource audioSource;
    private Image buttonImage;
    public Sprite SoundOnSprite;
    public Sprite SoundOffSprite;
    private bool soundOn;
    public float volume = 1;
    private void Update()
    {
        Load();
        ValueSound();
        audioSource.volume = sliderAudio.value;
    }
    public void SliderSound()
    {
        volume = sliderAudio.value;
        Save();
        ValueSound();
    }
    public void OnOffAudio()
    {
        if(AudioListener.volume == 1)
        {
            volume = 0;
            buttonAudio.GetComponent<Image>().sprite = SoundOffSprite;
        }
        else
        {
            volume = 1;
            buttonAudio.GetComponent <Image>().sprite = SoundOnSprite;
        }
        Save();
        ValueSound();
    }
    private void ValueSound()
    {
        audioSource.volume = volume;
        sliderAudio.value = volume;
        if(volume == 0)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = SoundOffSprite;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = SoundOnSprite;
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volume);
    }

    private void Load()
    {
        volume = PlayerPrefs.GetFloat("volume", volume);
    }

    
}
