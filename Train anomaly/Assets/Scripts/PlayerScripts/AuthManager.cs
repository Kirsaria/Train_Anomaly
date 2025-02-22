using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AuthManager : MonoBehaviour
{
    private string filePath; 
    private UserList userList;
    private string currentUsername;

    private void Start()
    {
        DontDestroyOnLoad(this);
        filePath = Path.Combine(Application.dataPath, "users.json");
        LoadUsers(); 
    }

    private void LoadUsers()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            userList = JsonUtility.FromJson<UserList>(json);
        }
        else
        {
            userList = new UserList { users = new List<UserData>() };
        }
    }

    private void SaveUsers()
    {
        string json = JsonUtility.ToJson(userList, true);
        File.WriteAllText(filePath, json);
    }

    public bool Register(string username, string password)
    {
        if (userList.users.Exists(u => u.username == username))
        {
            Debug.LogWarning("Пользователь с таким именем уже существует.");
            return false;
        }

        UserData newUser = new UserData
        {
            username = username,
            password = password,
            correctAnswers = 0,
            difficultyLevel = 0
        };

        userList.users.Add(newUser);
        SaveUsers(); 
        Debug.Log("Пользователь зарегистрирован: " + username);
        return true;
    }
    public bool Login(string username, string password)
    {
        UserData user = userList.users.Find(u => u.username == username && u.password == password);
        if (user != null)
        {
            Debug.Log("Пользователь авторизован: " + username);
            currentUsername = username;
            return true;
        }

        Debug.LogWarning("Неверное имя пользователя или пароль.");
        return false;
    }

    public UserData GetUserData(string username)
    {
        return userList.users.Find(u => u.username == username);
    }

    public void UpdateUserData(string username, int correctAnswers)
    {
        UserData user = userList.users.Find(u => u.username == username);
        if (user != null)
        {
            user.correctAnswers = correctAnswers;
            SaveUsers(); 
        }
    }

    public void UpdateDifficultyLevel(string username, int difficultyLevel)
    {
        UserData user = userList.users.Find(u => u.username == username);
        if (user != null)
        {
            user.difficultyLevel = difficultyLevel;
            SaveUsers();
        }
    }

    public void ResetProgress(string username)
    {
        UserData user = userList.users.Find(u => u.username == username);
        if (user != null)
        {
            user.correctAnswers = 0;
            SaveUsers();
        }
    }
    public string GetCurrentUser()
    {
        return currentUsername;
    }
}