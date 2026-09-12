using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayDropdowns : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    [Header("Default Settings")]
    [SerializeField] private ChallangeLevel defaultChallangeLevel = ChallangeLevel.Normal;
    [SerializeField] private SubtitlesMode defaultSubtitlesMode = SubtitlesMode.On;
    [SerializeField] private GameHintMode defaultGameHintMode = GameHintMode.On;
    [SerializeField] private TutorialsMode defaultTutorialMode = TutorialsMode.On;
    [SerializeField] private PhotoMode defaultPhotoMode = PhotoMode.Off;

    private void Awake()
    {
        if (manager == null) return;

        GameplayOptions<ChallangeLevel>(manager.refrences.ChallangeDropdown);
        GameplayOptions<SubtitlesMode>(manager.refrences.GameplaySubtitlesDropdown);
        GameplayOptions<GameHintMode>(manager.refrences.GameHintDropdown);
        GameplayOptions<TutorialsMode>(manager.refrences.TuturialsDropdown);
        GameplayOptions<PhotoMode>(manager.refrences.PhotoModeDropdown);

        LoadData(manager.refrences.ChallangeDropdown, GameData.CHALLANGE_MODE, (int)defaultChallangeLevel);
        LoadData(manager.refrences.GameplaySubtitlesDropdown, GameData.SUBTITLE_MODE, (int)defaultSubtitlesMode);
        LoadData(manager.refrences.GameHintDropdown, GameData.GAME_HINT_MODE, (int)defaultGameHintMode);
        LoadData(manager.refrences.TuturialsDropdown, GameData.TUTORIALS_MODE, (int)defaultTutorialMode);
        LoadData(manager.refrences.PhotoModeDropdown, GameData.PHOTO_MODE, (int)defaultPhotoMode);

        DropdownsListeners();
    }

    #region OnDropdownsValuesChanged
    public void OnChallangeChanged(int index)
    {
        PlayerPrefs.SetInt(GameData.CHALLANGE_MODE, index);
        PlayerPrefs.Save();
    }

    public void OnSubtitleChanged(int index)
    {
        PlayerPrefs.SetInt(GameData.SUBTITLE_MODE, index);
        PlayerPrefs.Save();
    }

    public void OnGameHintChanged(int index)
    {
        PlayerPrefs.SetInt(GameData.GAME_HINT_MODE, index);
        PlayerPrefs.Save();
    }

    public void OnTutorialChanged(int index)
    {
        PlayerPrefs.SetInt(GameData.TUTORIALS_MODE, index);
        PlayerPrefs.Save();
    }

    public void OnPhotoModeChanged(int index)
    {
        PlayerPrefs.SetInt(GameData.PHOTO_MODE, index);
        PlayerPrefs.Save();
    }
    #endregion

    #region General
    private void DropdownsListeners()
    {
        manager.refrences.ChallangeDropdown.onValueChanged.AddListener(OnChallangeChanged);
        manager.refrences.GameplaySubtitlesDropdown.onValueChanged.AddListener(OnSubtitleChanged);
        manager.refrences.GameHintDropdown.onValueChanged.AddListener(OnGameHintChanged);
        manager.refrences.TuturialsDropdown.onValueChanged.AddListener(OnTutorialChanged);
        manager.refrences.PhotoModeDropdown.onValueChanged.AddListener(OnPhotoModeChanged);
    }

    private void GameplayOptions<T>(TMP_Dropdown dropdown) where T : System.Enum
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

    private void LoadData(TMP_Dropdown dropdown, string prefId, int defaultValue)
    {
        if (dropdown == null) return;

        int savedValue = PlayerPrefs.GetInt(prefId, defaultValue);

        if (savedValue < 0 || savedValue >= dropdown.options.Count)
            savedValue = defaultValue;

        dropdown.SetValueWithoutNotify(savedValue);
        dropdown.RefreshShownValue();
    }
    #endregion
}