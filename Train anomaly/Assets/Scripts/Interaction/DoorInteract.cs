using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorInteract : MonoBehaviour, IInteractable
{
    public bool isInteract;
    public Button yesButton;
    public Button noButton;
    public GameObject questionUI;
    public Text questionText;
    private CountAnomaly countAnomaly;

    public void Start()
    {
        countAnomaly = FindObjectOfType<CountAnomaly>();
        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
    }
    public string GetDescription()
    {
        if (!isInteract)
            return "Нажмите [E], чтобы взаимодействовать";
        else return "";
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
        questionUI.SetActive(true);
    }

    private void CloseAnomalyWindow()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        questionUI.SetActive(false);
        isInteract = false;
    }

    private void OnYesClicked()
    {
        CheckAnswer(true);
    }

    private void OnNoClicked()
    {
        CheckAnswer(false);
    }

    private void CheckAnswer(bool isYesClicked)
    {
        switch (isYesClicked)
        {
            case true when countAnomaly.anomaliIs:
                Debug.Log("Correct");
                CloseAnomalyWindow();
                break;
            case false when !countAnomaly.anomaliIs:
                Debug.Log("Correct");
                CloseAnomalyWindow();
                break;
            default:
                Debug.Log("Incorrect");
                CloseAnomalyWindow();
                break;
        }        
    }
}
