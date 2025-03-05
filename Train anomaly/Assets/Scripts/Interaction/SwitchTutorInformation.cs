using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SwitchTutorInformation : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public TMP_Text descriptionText;
    public VideoClip[] videoClips;
    public string[] descriptions;
    public Button rightButton;
    public Button leftButton;
    private int currentIndex = 0;

    private void Start()
    {
        UpdateContent();
        rightButton.onClick.AddListener(NextContent);
        leftButton.onClick.AddListener(BackContent);
    }

    public void NextContent()
    {
        currentIndex = (currentIndex + 1) % videoClips.Length;
        UpdateContent();
    }

    public void BackContent()
    {
        currentIndex = (currentIndex - 1 + videoClips.Length) % videoClips.Length;
        UpdateContent();
    }

    private void UpdateContent()
    {
        videoPlayer.clip = videoClips[currentIndex];
        descriptionText.text = descriptions[currentIndex];
    }
}
