using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleSound : MonoBehaviour
{
    public Button toggleButton;
    private Image buttonImage;
    public Sprite SoundOnSprite;
    public Sprite SoundOffSprite;
    private bool soundOn;
    void Start()
    {
        buttonImage = toggleButton.GetComponent<Image>();
        toggleButton.onClick.AddListener(ToggleSoundOn);
    }

    void ToggleSoundOn()
    {
        soundOn = !soundOn;
        if(soundOn)
        {
            buttonImage.sprite = SoundOnSprite;
        }
        else
        {
            buttonImage.sprite = SoundOffSprite;
        }
    }
}
