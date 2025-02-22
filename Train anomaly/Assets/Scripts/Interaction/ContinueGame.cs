using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    public List<string> sceneNames;
    private AuthManager authManager;
    private void Start()
    {
        authManager = FindObjectOfType<AuthManager>();
    }
    private void LoadRandomScene()
    {
        if (sceneNames.Count > 0)
        {
            int randomIndex = Random.Range(0, sceneNames.Count);
            SceneManager.LoadScene(sceneNames[randomIndex]);
        }
        else
        {
            Debug.LogWarning("Список сцен пуст!");
        }
    }
    public void Continue()
    {
        string currentUsername = authManager.GetCurrentUser();
        if (!string.IsNullOrEmpty(currentUsername))
        {
            UserData userData = authManager.GetUserData(currentUsername);
            if (userData != null)
            {
                Debug.Log("Загружаем игру с уровнем сложности: " + userData.difficultyLevel);
                LoadRandomScene();
            }
        }
        else
        {
            Debug.LogWarning("Пользователь не авторизован.");
        }
    }
}
