using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevel : MonoBehaviour
{
    public static int difficultyLevel; 
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SetEasyDifficulty()
    {   
        difficultyLevel = 0;
        Invoke("LoadGameScene", 0.5f);
    }

    public void SetHardDifficulty()
    {
        difficultyLevel = 1;
        Invoke("LoadGameScene", 0.5f);
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
}
