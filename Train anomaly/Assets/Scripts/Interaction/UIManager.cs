using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class UIManager : MonoBehaviour
{
    public TMP_InputField registerUsernameInput;
    public TMP_InputField registerPasswordInput;
    public TMP_InputField loginUsernameInput;
    public TMP_InputField loginPasswordInput;
    public TextMeshProUGUI statusTextRegister;
    public TextMeshProUGUI statusTextLogin;
    public TMP_InputField registerConfirmPasswordInput;
    public GameObject registerWindow;
    public GameObject loginWindow;
    public GameObject menuWindow;

    private AuthManager authManager;
    private GameProgressManager progressManager;

    private void Start()
    {
        authManager = FindObjectOfType<AuthManager>();
        progressManager = GameProgressManager.Instance;
    }

    public void OnRegisterButtonClicked()
    {
        string username = registerUsernameInput.text;
        string password = registerPasswordInput.text;
        string confirmPassword = registerConfirmPasswordInput.text;

        if (!IsUsernameValid(username))
        {
            statusTextRegister.text = "Логин должен содержать только буквы, цифры и символы подчёркивания.";
            return;
        }

        if (!IsPasswordValid(password))
        {
            statusTextRegister.text = "Пароль должен быть не менее 8 символов, содержать хотя бы одну заглавную букву, одну строчную букву и одну цифру.";
            return;
        }

        if (password != confirmPassword)
        {
            statusTextRegister.text = "Пароли не совпадают.";
            return;
        }

        if (authManager.Register(username, password))
        {
            statusTextRegister.text = "Регистрация успешна!";
            progressManager.SetCurrentUser(username);
            registerWindow.SetActive(false);
            menuWindow.SetActive(true);
        }
        else
        {
            statusTextRegister.text = "Ошибка регистрации.";
        }
    }

    public void OnLoginButtonClicked()
    {
        string username = loginUsernameInput.text;
        string password = loginPasswordInput.text;

        if (!IsUsernameValid(username))
        {
            statusTextLogin.text = "Логин должен содержать только буквы, цифры и символы подчёркивания.";
            return;
        }

        if (!IsPasswordValid(password))
        {
            statusTextLogin.text = "Пароль должен быть не менее 8 символов, содержать хотя бы одну заглавную букву, одну строчную букву и одну цифру.";
            return;
        }

        if (authManager.Login(username, password))
        {
            statusTextLogin.text = "Авторизация успешна!";
            progressManager.SetCurrentUser(username);
            UserData userData = authManager.GetUserData(username);
            Debug.Log($"Пользователь: {userData.username}, Правильных ответов: {userData.correctAnswers}");
            loginWindow.SetActive(false);
            menuWindow.SetActive(true);
        }
        else
        {
            statusTextLogin.text = "Ошибка авторизации.";
        }
    }
    private bool IsUsernameValid(string username)
    {
        // Логин должен содержать только буквы, цифры и символы подчёркивания
        string pattern = @"^[a-zA-Z0-9_]+$";
        return Regex.IsMatch(username, pattern);
    }

    private bool IsPasswordValid(string password)
    {
        // Пароль должен быть не менее 8 символов, содержать хотя бы одну заглавную букву, одну строчную букву и одну цифру
        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
        return Regex.IsMatch(password, pattern);
    }
}