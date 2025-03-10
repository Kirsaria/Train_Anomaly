using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Threading.Tasks;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GoFinalScene : MonoBehaviour
{
    private DialogeStory dialogeStory;
    [SerializeField] private string[] GoingTags;
    public GameObject finalScene;
    public GameObject credits;
    private void Start()
    {
        dialogeStory = FindObjectOfType<DialogeStory>();
        dialogeStory.ChangedStory += Final;
    }

    private async void Final(DialogeStory.Story story)
    {
        if (GoingTags.All(GoingTags => story.Tag != GoingTags)) return;
        await Task.Delay(5000);
        Time.timeScale = 1;
        finalScene.SetActive(true);
        DisableAllSounds();
    }
    void DisableAllSounds()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop(); 
            audioSource.enabled = false; 
        }
    }
}
