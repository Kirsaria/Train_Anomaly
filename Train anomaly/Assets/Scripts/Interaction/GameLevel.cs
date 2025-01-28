using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevel : MonoBehaviour
{
    public static int difficultyLevel; // 0 - кнопки, 1 - ввод количества
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SetEasyDifficulty()
    {   
        difficultyLevel = 0; // Уровень с кнопками
        LoadGameScene();
    }

    public void SetHardDifficulty()
    {
        difficultyLevel = 1; // Уровень с вводом количества
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
}
