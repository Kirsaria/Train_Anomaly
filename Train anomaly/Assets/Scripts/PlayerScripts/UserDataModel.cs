using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string username; 
    public string password; 
    public int correctAnswers;
    public int difficultyLevel;
}

[System.Serializable]
public class UserList
{
    public List<UserData> users; 

    public UserList()
    {
        users = new List<UserData>();
    }
}