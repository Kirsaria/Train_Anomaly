using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    private bool hasPlayed = false;
    public PlayableDirector director;

    void OnEnable()
    {
        if (!hasPlayed)
        {
            director.Play();
            hasPlayed = true;
        }
    }

    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }
}
