using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtons : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    private TextMeshProUGUI[] buttonsText;
    private string[] currentReplyTags;
    private DialogeStory dialogeStory;

    private void Start()
    {
        dialogeStory = GetComponent<DialogeStory>();
        dialogeStory.ChangedStory += ChangeAnswers;
        buttonsText = new TextMeshProUGUI[buttons.Length];
        currentReplyTags = new string[buttons.Length];

        for(int i = 0; i < buttons.Length; i++)
        {
            int button = i;
            buttons[i].onClick.AddListener(() => SendAnswer(button));
            buttonsText[i] = buttons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    private void ChangeAnswers(DialogeStory.Story story)
    {
        for(int i = 0;i < buttons.Length;i++)
        {
            if(story.Answers.Length <= i)
            {
                buttonsText[i].text = null;
                buttons[i].interactable = false;
                continue;
            }

            buttonsText[i].text = story.Answers[i].Text;
            currentReplyTags[i] = story.Answers[i].ReposeText;
            buttons[i].interactable = true;
        }
    }

    private void SendAnswer(int button) => dialogeStory.ChangeStory(currentReplyTags[button]);
}
