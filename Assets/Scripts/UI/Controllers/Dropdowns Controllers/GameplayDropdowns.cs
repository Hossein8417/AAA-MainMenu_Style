using System.Collections.Generic;
using UnityEngine;

public class GameplayDropdowns : MonoBehaviour 
{
    [SerializeField]
    private UIManager _manager;

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
        ChallangeOptions();
        SubtitleOptions();
        GameHintOptions();
        TutorialOptions();
        PhotoModeOptions();

        LoadData();

        DropdownsListeners();
    }

    #region OnDropdownsValuesChanged
    public void OnChallangeChanged(int index)
    {
        PlayerPrefs.SetInt(GameData.CHALLANGE_MODE, index);
        PlayerPrefs.Save();

        ChallangeLevel selectedLevel = (ChallangeLevel)index;
        Debug.Log($"challange level set to: {selectedLevel}");

    }
    public void OnSubtitleChanged(int index) {
        PlayerPrefs.SetInt(GameData.SUBTITLE_MODE, index);
        PlayerPrefs.Save();

        SubtitlesMode selectedMode = (SubtitlesMode)index;
        Debug.Log($"subtitle mode set to : {selectedMode}");
    }
    public void OnGameHintChanged(int index) {
        PlayerPrefs.SetInt(GameData.GAME_HINT_MODE, index);
        PlayerPrefs.Save();

        GameHintMode selectedGameHintMode = (GameHintMode)index;
        Debug.Log($"game hint set to : {selectedGameHintMode}");
    }
    public void OnTutorialChanged(int index) {
        PlayerPrefs.SetInt(GameData.TUTORIALS_MODE, index);
        PlayerPrefs.Save();

        TutorialsMode savedMode = (TutorialsMode)index;
        Debug.Log($"tutorail mode set to {savedMode}");
    }
    public void OnPhotoModeChanged(int index) {
        PlayerPrefs.SetInt(GameData.PHOTO_MODE, index);
        PlayerPrefs.Save();

        PhotoMode selectedPhotoMode = (PhotoMode)index;
        Debug.Log($"photo mode set to {selectedPhotoMode}");
    }


    #endregion

    #region InitalizeOptions
    private void ChallangeOptions()
    {
        _manager.refrences.ChallangeDropdown.ClearOptions();

        List<string> options = new List<string>();
        foreach (ChallangeLevel level in System.Enum.GetValues(typeof(ChallangeLevel)))
        {
            options.Add(level.ToString());
        }

        _manager.refrences.ChallangeDropdown.AddOptions(options);
    }
    private void SubtitleOptions() { 
        _manager.refrences.GameplaySubtitlesDropdown.ClearOptions();

        List<string> options = new List<string>();
        foreach (SubtitlesMode mode in System.Enum.GetValues(typeof(SubtitlesMode)))
        {
            options.Add(mode.ToString());
        }

        _manager.refrences.GameplaySubtitlesDropdown.AddOptions(options);
    }
    private void GameHintOptions() {
        _manager.refrences.GameHintDropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach (GameHintMode mode in System.Enum.GetValues(typeof(GameHintMode)))
        {
            options.Add(mode.ToString());
        }

        _manager.refrences.GameHintDropdown.AddOptions(options);
    }
    private void TutorialOptions(){
        _manager.refrences.TuturialsDropdown.ClearOptions();

        List<string> options =new List<string>();
        foreach (TutorialsMode mode in System.Enum.GetValues(typeof(TutorialsMode)))
        {
            options.Add((mode.ToString()));
        }

        _manager.refrences.TuturialsDropdown.AddOptions(options);
    }
    private void PhotoModeOptions() { 
        _manager.refrences.PhotoModeDropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach (PhotoMode mode in System.Enum.GetValues(typeof(PhotoMode)))
        {
            options.Add(mode.ToString());
        }
        _manager.refrences.PhotoModeDropdown.AddOptions(options);
    }

    #endregion

    #region LoadDefaultValues Methods

    private void LoadDefaultChallangeLevel()
    {
        int savedChallengeMode = PlayerPrefs.GetInt(
            GameData.CHALLANGE_MODE,
            (int)defaultChallangeLevel
        );

        int optionCount = System.Enum.GetValues(typeof(ChallangeLevel)).Length;

        if (savedChallengeMode < 0 || savedChallengeMode >= optionCount)
        {
            savedChallengeMode = (int)defaultChallangeLevel;
        }

        _manager.refrences.ChallangeDropdown.value = savedChallengeMode;
        _manager.refrences.ChallangeDropdown.RefreshShownValue();
    }


    private void LoadDefaultSubtitleMode()
    {
        int savedSubtitleMode = PlayerPrefs.GetInt(
            GameData.SUBTITLE_MODE,
            (int)defaultSubtitlesMode
        );

        int optionCount = System.Enum.GetValues(typeof(SubtitlesMode)).Length;

        if (savedSubtitleMode < 0 || savedSubtitleMode >= optionCount)
        {
            savedSubtitleMode = (int)defaultSubtitlesMode;
        }

        _manager.refrences.GameplaySubtitlesDropdown.value = savedSubtitleMode;
        _manager.refrences.GameplaySubtitlesDropdown.RefreshShownValue();
    }


    private void LoadDefaultGameHintMode()
    {
        int savedGameHintMode = PlayerPrefs.GetInt(
            GameData.GAME_HINT_MODE,
            (int)defaultGameHintMode
        );

        int optionCount = System.Enum.GetValues(typeof(GameHintMode)).Length;

        if (savedGameHintMode < 0 || savedGameHintMode >= optionCount)
        {
            savedGameHintMode = (int)defaultGameHintMode;
        }

        _manager.refrences.GameHintDropdown.value = savedGameHintMode;
        _manager.refrences.GameHintDropdown.RefreshShownValue();
    }


    private void LoadDefaultTutorialMode()
    {
        int savedTutorialMode = PlayerPrefs.GetInt(
            GameData.TUTORIALS_MODE,
            (int)defaultTutorialMode
        );

        int optionCount = System.Enum.GetValues(typeof(TutorialsMode)).Length;

        if (savedTutorialMode < 0 || savedTutorialMode >= optionCount)
        {
            savedTutorialMode = (int)defaultTutorialMode;
        }

        _manager.refrences.TuturialsDropdown.value = savedTutorialMode;
        _manager.refrences.TuturialsDropdown.RefreshShownValue();
    }


    private void LoadDefaultPhotoMode()
    {
        int savedPhotoMode = PlayerPrefs.GetInt(
            GameData.PHOTO_MODE,
            (int)defaultPhotoMode
        );

        int optionCount = System.Enum.GetValues(typeof(PhotoMode)).Length;

        if (savedPhotoMode < 0 || savedPhotoMode >= optionCount)
        {
            savedPhotoMode = (int)defaultPhotoMode;
        }

        _manager.refrences.PhotoModeDropdown.value = savedPhotoMode;
        _manager.refrences.PhotoModeDropdown.RefreshShownValue();
    }

    #endregion

    #region General
    private void LoadData() {
        LoadDefaultChallangeLevel();
        LoadDefaultSubtitleMode();
        LoadDefaultGameHintMode();
        LoadDefaultTutorialMode();
        LoadDefaultPhotoMode();
    }
    private void DropdownsListeners() {
        _manager.refrences.ChallangeDropdown.onValueChanged.AddListener(OnChallangeChanged);
        _manager.refrences.GameplaySubtitlesDropdown.onValueChanged.AddListener(OnSubtitleChanged);
        _manager.refrences.GameHintDropdown.onValueChanged.AddListener(OnGameHintChanged);
        _manager.refrences.TuturialsDropdown.onValueChanged.AddListener(OnTutorialChanged);
        _manager.refrences.PhotoModeDropdown.onValueChanged.AddListener(OnPhotoModeChanged);
    }
    #endregion
}