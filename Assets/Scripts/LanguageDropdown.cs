using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;

public class LanguageDropdown : MonoBehaviour
{
    private TMP_Dropdown languageDropdown;

    private void Awake()
    {
        languageDropdown = GetComponent<TMP_Dropdown>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Add event listener to the dropdown
        languageDropdown.onValueChanged.AddListener(SetLocale);
    }

    void SetLocale(int option)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[option];
    }
}
