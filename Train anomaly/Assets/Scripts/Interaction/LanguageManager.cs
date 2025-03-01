using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LanguageManager : MonoBehaviour
{
    public int language;
    private bool languageRu;
    public Button languageButton;

    private void Start()
    {
        language = PlayerPrefs.GetInt("language", 0); 
        languageRu = (language == 0);
        language = PlayerPrefs.GetInt("language", language);
        languageButton.onClick.AddListener(ToggleLanguage);
    }

    void ToggleLanguage()
    {
        languageRu = !languageRu;
        if(languageRu)
        {
            SetRussian();
        }
        else
        {
            SetEnglish();
        }
    }
    public void SetRussian()
    {
        language = 0;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("MainMenu");
    }
    public void SetEnglish()
    {
        language = 1;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("MainMenu");
    }
}
