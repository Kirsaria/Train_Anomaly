using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayAudio()
    {
        audioSource.Play();
    }
}
