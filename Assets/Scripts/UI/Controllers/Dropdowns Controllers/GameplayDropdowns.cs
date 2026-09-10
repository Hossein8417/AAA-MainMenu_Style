using System.Collections.Generic;
using TMPro;
using UnityEditor.Presets;
using UnityEngine;

public class GameplayDropdowns : MonoBehaviour 
{
    [SerializeField]
    private UIManager manager;

    [Header("Defualt Settings")]
    [SerializeField]
    private ChallangeLevel defaultChallangeLevel;

    [SerializeField]
    private SubtitlesMode defaultSubtitlesMode;

    [SerializeField]
    private GameHintMode defaultGameHintMode;

    [SerializeField]
    private TutorialsMode defaultTutorialMode;

    [SerializeField]
    private PhotoMode defaultPhotoMode;

    private void Awake()
    {
        GameplayOptions<ChallangeLevel>(manager.refrences.ChallangeDropdown);
        GameplayOptions<SubtitlesLanguages>(manager.refrences.GameplaySubtitlesDropdown);
        GameplayOptions<GameHintMode>(manager.refrences.GameHintDropdown);
        GameplayOptions<TutorialsMode>(manager.refrences.TuturialsDropdown);
        GameplayOptions<PhotoMode>(manager.refrences.PhotoModeDropdown);

        LoadData<ChallangeLevel>(manager.refrences.ChallangeDropdown, GameData.CHALLANGE_MODE, (int)defaultChallangeLevel);
        LoadData<SubtitlesLanguages>(manager.refrences.GameplaySubtitlesDropdown, GameData.SUBTITLE_MODE, (int)defaultSubtitlesMode);
        LoadData<GameHintMode>(manager.refrences.GameHintDropdown, GameData.GAME_HINT_MODE, (int)defaultGameHintMode);
        LoadData<TutorialsMode>(manager.refrences.TuturialsDropdown, GameData.TUTORIALS_MODE, (int)defaultTutorialMode);
        LoadData<PhotoMode>(manager.refrences.PhotoModeDropdown, GameData.PHOTO_MODE, (int)defaultPhotoMode);

        DropdownsListeners();
    }
    #region OnDropdownsValuesChanged
    public void OnChallangeChanged(int index)
    {
        PlayerPrefs.SetInt(GameData.CHALLANGE_MODE, index);
        PlayerPrefs.Save();

        ChallangeLevel selectedLevel = (ChallangeLevel)index;
    }
    public void OnSubtitleChanged(int index) {
        PlayerPrefs.SetInt(GameData.SUBTITLE_MODE, index);
        PlayerPrefs.Save();

        SubtitlesMode selectedMode = (SubtitlesMode)index;
    }
    public void OnGameHintChanged(int index) {
        PlayerPrefs.SetInt(GameData.GAME_HINT_MODE, index);
        PlayerPrefs.Save();

        GameHintMode selectedGameHintMode = (GameHintMode)index;
    }
    public void OnTutorialChanged(int index) {
        PlayerPrefs.SetInt(GameData.TUTORIALS_MODE, index);
        PlayerPrefs.Save();

        TutorialsMode savedMode = (TutorialsMode)index;
    }
    public void OnPhotoModeChanged(int index) {
        PlayerPrefs.SetInt(GameData.PHOTO_MODE, index);
        PlayerPrefs.Save();

        PhotoMode selectedPhotoMode = (PhotoMode)index;
    }
    #endregion

    #region General

    private void DropdownsListeners() {
        manager.refrences.ChallangeDropdown.onValueChanged.AddListener(OnChallangeChanged);
        manager.refrences.GameplaySubtitlesDropdown.onValueChanged.AddListener(OnSubtitleChanged);
        manager.refrences.GameHintDropdown.onValueChanged.AddListener(OnGameHintChanged);
        manager.refrences.TuturialsDropdown.onValueChanged.AddListener(OnTutorialChanged);
        manager.refrences.PhotoModeDropdown.onValueChanged.AddListener(OnPhotoModeChanged);
    }

    private void GameplayOptions<T>(TMP_Dropdown dropdown) where T : System.Enum
    {
        dropdown.ClearOptions();

        List<string> options = new List<string>();
        foreach (T item in System.Enum.GetValues(typeof(T)))
        {
            options.Add(item.ToString());
        }

        dropdown.AddOptions(options);
    }
    private void LoadData<T>(TMP_Dropdown dropdown, string prefId, int value) where T : System.Enum
    {
        int savedLevel = PlayerPrefs.GetInt(prefId, value);
        if (PlayerPrefs.HasKey(prefId))
        {
            dropdown.value = savedLevel;
            dropdown.RefreshShownValue();
        }
        else
        {
            dropdown.value = value;
            dropdown.RefreshShownValue();
        }
    }
    #endregion
}