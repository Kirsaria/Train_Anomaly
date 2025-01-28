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
            return "������� [E], ����� �����������������";
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

        // ��������� ������������ ��������� � ����������� �� ������ ���������
        if (GameLevel.difficultyLevel == 1) // ������� � ������ ����������
        {
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            anomalyCountInput.gameObject.SetActive(true);
        }
        else // ������� � ��������
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
        // ���������, ���� �������� ����� �� ������ � ������ ������� Enter
        if (!string.IsNullOrEmpty(input) && Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer(false); // �������� CheckAnswer � ������ false, ��� ��� ������� Enter �� �������� "��"
        }
    }
    private void CheckAnswer(bool isYesClicked)
    {
        switch (GameLevel.difficultyLevel)
        {
            case 0: // ������� � ��������
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

            case 1: // ������� � ������ ����������
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
