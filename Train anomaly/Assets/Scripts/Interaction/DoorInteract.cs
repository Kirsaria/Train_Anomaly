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
    private GameLevel gameLevel;
    public InputField anomalyCountInput;
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

        // Управляем отображением элементов в зависимости от уровня сложности
        if (GameLevel.difficultyLevel == 1) // Уровень с вводом количества
        {
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            anomalyCountInput.gameObject.SetActive(true);
        }
        else // Уровень с кнопками
        {
            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);
            anomalyCountInput.gameObject.SetActive(false);
        }
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
    private void OnEndEdit(string input)
    {
        // Проверяем, если введённый текст не пустой и нажата клавиша Enter
        if (!string.IsNullOrEmpty(input) && Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer(false); // Вызываем CheckAnswer с флагом false, так как нажатие Enter не является "Да"
        }
    }
    private void CheckAnswer(bool isYesClicked)
    {
        switch (GameLevel.difficultyLevel)
        {
            case 0: // Уровень с кнопками
                if ((isYesClicked && countAnomaly.anomaliIs) || (!isYesClicked && !countAnomaly.anomaliIs))
                {
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Incorrect");
                }
                CloseAnomalyWindow();
                break;

            case 1: // Уровень с вводом количества
                int inputCount;
                if (int.TryParse(anomalyCountInput.text, out inputCount) && inputCount == countAnomaly.countAnomaly)
                {
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Incorrect");
                }
                CloseAnomalyWindow();
                break;
        }
    }
}
