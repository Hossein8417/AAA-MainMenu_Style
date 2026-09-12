using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using UnityEngine;
using TMPro;

public class LanguageDropDownsController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private UIManager manager;

    [Header("Settings")]
    [SerializeField] private TextLanguages defaultTextLan = TextLanguages.English;
    [SerializeField] private SubtitlesLanguages defaultSubtitlesLan = SubtitlesLanguages.English;
    [SerializeField] private SpeechLanguages defaultSpeechLan = SpeechLanguages.English;
    [SerializeField] private string defaultLanguageLocale = "en";

    private List<Locale> availableLocals = new List<Locale>();

    private void Awake()
    {
        if (manager == null) return;

        DropDownsSettings<TextLanguages>(manager.refrences.TextDropdown);
        DropDownsSettings<SubtitlesLanguages>(manager.refrences.LanguageSubtitlesDropdown);
        DropDownsSettings<SpeechLanguages>(manager.refrences.SpeechDropdown);

        LanguageListeners();
    }

    private void Start()
    {
        StartCoroutine(InitializeLocales());
    }

    #region Load
    private void LoadDefaultLanguage<T>(TMP_Dropdown dropdown, string prefId, int defaultValue) where T : System.Enum
    {
        if (dropdown == null) return;

        int savedLanguage = PlayerPrefs.GetInt(prefId, defaultValue);

        if (savedLanguage < 0 || savedLanguage >= System.Enum.GetValues(typeof(T)).Length)
            savedLanguage = defaultValue;

        dropdown.SetValueWithoutNotify(savedLanguage);
        dropdown.RefreshShownValue();
    }

    private void LoadDefaultGameLanguage()
    {
        string savedLocale = PlayerPrefs.GetString(GameData.LANGUAGE_LOCALE, defaultLanguageLocale);

        int selectedIndex = 0;

        for (int i = 0; i < availableLocals.Count; i++)
        {
            if (availableLocals[i].Identifier.Code == savedLocale)
            {
                selectedIndex = i;
                break;
            }
        }

        manager.refrences.TextDropdown.SetValueWithoutNotify(selectedIndex);
        manager.refrences.TextDropdown.RefreshShownValue();

        ChangeLanguage(selectedIndex);
        PlayerPrefs.SetInt(GameData.TEXT_LANGUAGE, selectedIndex);
    }
    #endregion

    #region General
    private void LanguageListeners()
    {
        manager.refrences.TextDropdown.onValueChanged.AddListener(OnTextLanChanged);
        manager.refrences.LanguageSubtitlesDropdown.onValueChanged.AddListener(OnSubtitlesLanChanged);
        manager.refrences.SpeechDropdown.onValueChanged.AddListener(OnSpeechLanChanged);
    }

    private System.Collections.IEnumerator InitializeLocales()
    {
        yield return LocalizationSettings.InitializationOperation;

        availableLocals = LocalizationSettings.AvailableLocales.Locales;

        LoadDefaultGameLanguage();

        LoadDefaultLanguage<TextLanguages>(manager.refrences.TextDropdown,
            GameData.TEXT_LANGUAGE, (int)defaultTextLan);

        LoadDefaultLanguage<SubtitlesLanguages>(manager.refrences.LanguageSubtitlesDropdown,
            GameData.SUBTITLES_LANGUAGE, (int)defaultSubtitlesLan);

        LoadDefaultLanguage<SpeechLanguages>(manager.refrences.SpeechDropdown,
            GameData.SPEECH_LANGUAGE, (int)defaultSpeechLan);
    }

    private void DropDownsSettings<T>(TMP_Dropdown dropdown) where T : System.Enum
    {
        if (dropdown == null) return;

        dropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (T item in System.Enum.GetValues(typeof(T)))
        {
            options.Add(item.ToString());
        }

        dropdown.AddOptions(options);
    }

    private void ChangeLanguage(int index)
    {
        if (index < 0 || index >= availableLocals.Count) return;

        Locale selectedLocale = availableLocals[index];

        LocalizationSettings.SelectedLocale = selectedLocale;

        PlayerPrefs.SetString(GameData.LANGUAGE_LOCALE, selectedLocale.Identifier.Code);
        PlayerPrefs.Save();
    }
    #endregion

    #region OnValuesChanged
    private void OnTextLanChanged(int index)
    {
        ChangeLanguage(index);
        PlayerPrefs.SetInt(GameData.TEXT_LANGUAGE, index);
        PlayerPrefs.Save();
    }

    private void OnSubtitlesLanChanged(int index)
    {
        PlayerPrefs.SetInt(GameData.SUBTITLES_LANGUAGE, index);
        PlayerPrefs.Save();
    }

    private void OnSpeechLanChanged(int index)
    {
        PlayerPrefs.SetInt(GameData.SPEECH_LANGUAGE, index);
        PlayerPrefs.Save();
    }
    #endregion
}