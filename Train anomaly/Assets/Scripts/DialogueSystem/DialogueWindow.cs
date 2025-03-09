using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueWindow : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private DialogeStory _dialogeStory;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _dialogeStory = FindObjectOfType<DialogeStory>();
        _dialogeStory.ChangedStory += ChangeAnswers;
    }

    private void ChangeAnswers(DialogeStory.Story story) => _text.text = story.Text;
}
