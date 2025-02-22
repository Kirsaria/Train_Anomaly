using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevel : MonoBehaviour
{
    private AuthManager authManager;

    private void Start()
    {
        authManager = FindObjectOfType<AuthManager>();
    }

    public void SetEasyDifficulty()
    {
        SaveDifficultyLevel(0);
        string currentUsername = authManager.GetCurrentUser();
        authManager.ResetProgress(currentUsername);
        Invoke("LoadGameScene", 0.5f);
    }

    public void SetHardDifficulty()
    {
        SaveDifficultyLevel(1);
        string currentUsername = authManager.GetCurrentUser();
        authManager.ResetProgress(currentUsername);
        Invoke("LoadGameScene", 0.5f);
    }

    private void SaveDifficultyLevel(int difficultyLevel)
    {
        string currentUsername = authManager.GetCurrentUser();
        if (!string.IsNullOrEmpty(currentUsername))
        {
            authManager.UpdateDifficultyLevel(currentUsername, difficultyLevel);
            Debug.Log("Уровень сложности сохранен: " + difficultyLevel);
        }
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}