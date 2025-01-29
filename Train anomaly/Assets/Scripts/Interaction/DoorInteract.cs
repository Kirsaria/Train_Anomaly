using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DoorInteract : MonoBehaviour, IInteractable
{
    public bool isInteract;
    public Button yesButton;
    public Button noButton;
    public GameObject questionUIEasy;
    public GameObject questionUIHard;
    private CountAnomaly countAnomaly;
    public TMP_InputField anomalyCountInput;
    public List<string> sceneNames;
    public AudioSource buttonClickSound;

    public void Start()
    {
        countAnomaly = FindObjectOfType<CountAnomaly>();
        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
        anomalyCountInput.onEndEdit.AddListener(OnEndEdit);
    }

    public string GetDescription()
    {
        if (!isInteract)
            return "Нажмите [E], чтобы взаимодействовать";
        else return "";
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

    public void Interact()
    {
        isInteract = true;
        ShowAnomalyWindow();
    }

    private void ShowAnomalyWindow()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        if (GameLevel.difficultyLevel == 0)
        {
            questionUIEasy.SetActive(true);
        }
        else
        {
            questionUIHard.SetActive(true);
        }
    }

    private void CloseAnomalyWindow()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (GameLevel.difficultyLevel == 0)
        {
            questionUIEasy.SetActive(false);
        }
        else
        {
            questionUIHard.SetActive(false);
        }
        isInteract = false;
    }

    private void OnYesClicked()
    {
        PlayButtonClickSound();
        CheckAnswer(true);
    }

    private void OnNoClicked()
    {
        PlayButtonClickSound();
        CheckAnswer(false);
    }

    private void OnEndEdit(string input)
    {
        if (!string.IsNullOrEmpty(input) && Input.GetKeyDown(KeyCode.Return))
        {
            PlayButtonClickSound();
            CheckAnswer(false);
        }
    }

    private void CheckAnswer(bool isYesClicked)
    {
        switch (GameLevel.difficultyLevel)
        {
            case 0:
                if ((isYesClicked && countAnomaly.anomaliIs) || (!isYesClicked && !countAnomaly.anomaliIs))
                {
                    Debug.Log("Correct");
                    Invoke("LoadNextScene", 0.5f);
                }
                else
                {
                    Debug.Log("Incorrect");
                    Invoke("AgainScene", 0.5f);
                }
                CloseAnomalyWindow();
                break;

            case 1:
                int inputCount;
                if (int.TryParse(anomalyCountInput.text, out inputCount) && inputCount == countAnomaly.countAnomaly)
                {
                    Debug.Log("Correct");
                    LoadRandomScene();
                }
                else
                {
                    Debug.Log("Incorrect");
                    SceneManager.LoadScene("MainMenu");
                }
                CloseAnomalyWindow();
                break;
        }
    }
    private void LoadNextScene()
    {
        LoadRandomScene();
    }
    private void AgainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play(); 
        }
    }
}