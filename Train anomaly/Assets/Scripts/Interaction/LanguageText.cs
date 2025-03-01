using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LanguageText : MonoBehaviour
{
    public int language;
    public string[] text;
    private TextMeshProUGUI textLine;
    void Start()
    {
        language = PlayerPrefs.GetInt("language", language);
        textLine = GetComponent<TextMeshProUGUI>();
        textLine.text = "" + text[language];
    }

}
