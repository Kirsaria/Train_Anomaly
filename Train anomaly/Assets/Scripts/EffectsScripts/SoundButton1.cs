using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipSound;
    public Button[] buttons;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick());
        }
    }
    private void OnButtonClick()
    {
        PlayButtonClickSound();;
    }
    private void PlayButtonClickSound()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clipSound);
        }
    }

}
