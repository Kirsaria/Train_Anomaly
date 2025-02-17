using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
    public GameObject screamer;
    private void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("screamer") && other.CompareTag("Player"))
        {
            audio.PlayOneShot(clip);
        }
    }

    private void TurnOff()
    {
        screamer.SetActive(false);
    }
}
