using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogeStory : MonoBehaviour
{
    [SerializeField] private Story[] stories;
    private Dictionary<string, Story> storiesDict;
    public event Action<Story> ChangedStory;

    [Serializable]
    public struct Story
    {
        [field: SerializeField] public string Tag { get; private set; }
        [field: SerializeField] public string Text { get; private set; }
        [field: SerializeField] public Answer[] Answers { get; private set; }
    }

    [Serializable]
    public struct Answer
    {
        [field: SerializeField] public string Text { get; private set; }
        [field: SerializeField] public string ReposeText { get; private set; }
    }

    private void Start()
    {
        storiesDict = stories.ToDictionary(key => key.Tag, element => element);
        ChangeStory(stories[0].Tag);
    }

    public void ChangeStory(string tag) => ChangedStory?.Invoke(storiesDict[tag]);
}
