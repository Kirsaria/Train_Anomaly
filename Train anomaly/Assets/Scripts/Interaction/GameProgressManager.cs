using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgressManager : MonoBehaviour
{
    public static GameProgressManager Instance { get; private set; } 
    public int CorrectAnswersCount { get; private set; }

    private AuthManager authManager;
    private string currentUsername;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        authManager = FindObjectOfType<AuthManager>();
    }
    public void SetCurrentUser(string username)
    {
        currentUsername = username;
        LoadProgress();
    }
    public void IncrementCorrectAnswer()
    {
        CorrectAnswersCount++;
        Debug.Log($"Кол-во правильных сцен: {CorrectAnswersCount}");
        SaveProgress();
    }

    public void ResetCorrectAnswer()
    {
        CorrectAnswersCount = 0;
        Debug.Log("Счетчик правильных ответов сброшен");
        SaveProgress();
    }

    public bool IsGameComplete()
    {
        return CorrectAnswersCount >= 10;
    }

    public void CompleteGame()
    {
        Debug.Log("Игра завершена! Вы правильно ответили на 10 сцен.");
        SceneManager.LoadScene("FinalScene");
    }

    public void SaveProgress()
    {
        authManager.UpdateUserData(currentUsername, CorrectAnswersCount);
    }

    private void LoadProgress()
    {
        UserData userData = authManager.GetUserData(currentUsername);
        if (userData != null)
        {
            CorrectAnswersCount = userData.correctAnswers;
        }
    }
}
