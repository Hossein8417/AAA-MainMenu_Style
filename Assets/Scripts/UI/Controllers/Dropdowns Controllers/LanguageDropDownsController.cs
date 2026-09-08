using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using UnityEngine;

public class LanguageDropDownsController : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    [Header("Settings")]

    [SerializeField]
    private TextLanguages defaultTextLan;

    [SerializeField]
    private SubtitlesLanguages defaultSubtitlesLan;

    [SerializeField]
    private SpeechLanguages defaultSpeechLan;

    [SerializeField]
    private string defaultLanguageLocale;



    private List<Locale> availableLocals = new List<Locale>();
    private void Awake()
    {
        TextLanguageSettings();
        SubtitlesLanguageSettings();
        SpeechLanguageSettings();

        LanguageListeners();
    }

    private void Start()
    {
        StartCoroutine(InitializeLocales());
    }

    #region LoadDefaultValues
    private void LoadDefaultTextLan() {
        int savedLanguage = PlayerPrefs.GetInt(GameData.TEXT_LANGUAGE, (int)defaultTextLan);
        

        if (savedLanguage < 0 ||savedLanguage >= System.Enum.GetValues(typeof(TextLanguages)).Length)
        {
            manager.refrences.TextDropdown.value = (int)defaultTextLan;
            manager.refrences.TextDropdown.RefreshShownValue();
        }
        else
        {
            manager.refrences.TextDropdown.value = savedLanguage;
            manager.refrences.TextDropdown.RefreshShownValue();
        }
    }
    private void LoadDefaultSubtitlesLan() {
        int savedLanguage = PlayerPrefs.GetInt(GameData.SUBTITLES_LANGUAGE, (int)defaultSubtitlesLan);
        if (savedLanguage < 0 || savedLanguage >= System.Enum.GetValues(typeof(SubtitlesLanguages)).Length)
        {
            manager.refrences.LanguageSubtitlesDropdown.value = (int)defaultSubtitlesLan;
            manager.refrences.LanguageSubtitlesDropdown.RefreshShownValue();
        }
        else
        {
            manager.refrences.LanguageSubtitlesDropdown.value = savedLanguage;
            manager.refrences.LanguageSubtitlesDropdown.RefreshShownValue();
        }
    }
    private void LoadDefaultSpeechLan() {
        int savedLanguage = PlayerPrefs.GetInt(GameData.SPEECH_LANGUAGE, (int)defaultSpeechLan);
        if (savedLanguage < 0 || savedLanguage >= System.Enum.GetValues(typeof(SpeechLanguages)).Length)
        {
            manager.refrences.SpeechDropdown.value = (int)defaultSpeechLan;
            manager.refrences.SpeechDropdown.RefreshShownValue();
        }
        else
        {
            manager.refrences.SpeechDropdown.value = savedLanguage;
            manager.refrences.SpeechDropdown.RefreshShownValue();
        }
    }
    private void LoadDefaultGameLanguage()
    {
        string savedLocale = PlayerPrefs.GetString(
            GameData.LANGUAGE_LOCALE,
            defaultLanguageLocale
        );

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
    }

    #endregion

    #region General
    private void LoadData() {
        LoadDefaultTextLan();
        LoadDefaultSubtitlesLan();
        LoadDefaultSpeechLan();
    }

    private void LanguageListeners() {
        manager.refrences.TextDropdown.onValueChanged.AddListener(OnTextLanChanged);
        manager.refrences.LanguageSubtitlesDropdown.onValueChanged.AddListener(OnSubtitlesLanChanged);
        manager.refrences.SpeechDropdown.onValueChanged.AddListener(OnSpeechLanChanged);
    }

    private System.Collections.IEnumerator InitializeLocales()
    {
        yield return LocalizationSettings.InitializationOperation;

        availableLocals = LocalizationSettings.AvailableLocales.Locales;

        LoadDefaultGameLanguage();
        LoadData();
    }

    private void ChangeLanguage(int index)
    {
        if (index < 0 || index >= availableLocals.Count)
            return;

        Locale selectedLocale = availableLocals[index];

        LocalizationSettings.SelectedLocale = selectedLocale;

        PlayerPrefs.SetString(
            GameData.LANGUAGE_LOCALE,
            selectedLocale.Identifier.Code
        );

        PlayerPrefs.Save();
    }
    #endregion

    #region OnValues Changed
    private void OnTextLanChanged(int index) {
        ChangeLanguage(index);
        PlayerPrefs.SetInt(GameData.TEXT_LANGUAGE, index);
        PlayerPrefs.Save();
    }

    private void OnSubtitlesLanChanged(int index) {
        //SubtitlesLanguages lan set to value 
        PlayerPrefs.SetInt(GameData.SUBTITLES_LANGUAGE, index);
        PlayerPrefs.Save();
    }

    private void OnSpeechLanChanged(int index) {
        //speech lan set to value
        PlayerPrefs.SetInt(GameData.SPEECH_LANGUAGE, index);
        PlayerPrefs.Save();
    }
    #endregion

    #region Settings
    private void TextLanguageSettings() { 
        manager.refrences.TextDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (TextLanguages languages in System.Enum.GetValues(typeof(TextLanguages)))
        {
            options.Add(languages.ToString());
        }

        manager.refrences.TextDropdown.AddOptions(options);
    }

    private void SubtitlesLanguageSettings() {

        manager.refrences.LanguageSubtitlesDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (SubtitlesLanguages languages in System.Enum.GetValues(typeof(SubtitlesLanguages)))
        {
            options.Add(languages.ToString());
        }

        manager.refrences.LanguageSubtitlesDropdown.AddOptions(options);
    }

    private void SpeechLanguageSettings() {

        manager.refrences.SpeechDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (SpeechLanguages languages in System.Enum.GetValues(typeof(SpeechLanguages)))
        {
            options.Add(languages.ToString());
        }

        manager.refrences.SpeechDropdown.AddOptions(options);
    }
    #endregion   
}