using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class DialogueSwitcher : MonoBehaviour
{
    [SerializeField] private string[] disableTags;
    private DialogeStory dialogeStory;

    private void Start()
    {
        dialogeStory = FindObjectOfType<DialogeStory>();
        dialogeStory.ChangedStory += Disable;
    }

    private async void Disable(DialogeStory.Story story)
    {
        if (disableTags.All(disableTags => story.Tag != disableTags)) return;
        await Task.Delay(5000);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        dialogeStory.gameObject.SetActive(false);
    }
}
