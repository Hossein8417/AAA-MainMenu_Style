using System.Collections.Generic;
using UnityEngine; 
public class DisplayDropdowns : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private Resolution[] displayResolutions;
    private void Awake()
    {
        DisplayResolutionOptions();
        GetUserGPUInfo();
        GetAllMonitors();

        LoadData();

        DisplayListeners();
    }

    #region LoadDefaultSettings
    private void LoadDefualtDisplayResolution() {
        if (!PlayerPrefs.HasKey(GameData.DISPLAY_RESOLUTION))
        {
            int screenWidth = 1280;
            int screenHeight = 720;
            int defaultResolutionIndex = 3;
            Screen.SetResolution(screenWidth, screenHeight,Screen.fullScreenMode);
            manager.refrences.DisplayResolutionDropdown.value = defaultResolutionIndex;
            manager.refrences.DisplayResolutionDropdown.RefreshShownValue();
        }
        else {
            ApplyDisplayResolution(PlayerPrefs.GetInt(GameData.DISPLAY_RESOLUTION));

            int savedResolution = PlayerPrefs.GetInt(GameData.DISPLAY_RESOLUTION);
            manager.refrences.DisplayResolutionDropdown.value = savedResolution;
            manager.refrences.DisplayResolutionDropdown.RefreshShownValue();
        }  
    }
    #endregion

    #region OnValuesChanged
    private void OnDisplayResolutionChanged(int index)
    {
        ApplyDisplayResolution(index);
        PlayerPrefs.SetInt(GameData.DISPLAY_RESOLUTION, index);
    }

    private void OnMonitorChanged(int index) { 
        manager.refrences.DisplayMonitorDropdown.value = index;
        manager.refrences.DisplayMonitorDropdown.RefreshShownValue();
    }
    #endregion

    #region General
    private void DisplayListeners() {
        manager.refrences.DisplayResolutionDropdown.onValueChanged.AddListener(OnDisplayResolutionChanged);
        manager.refrences.DisplayMonitorDropdown.onValueChanged.AddListener(OnMonitorChanged);
    }
    private void GetUserGPUInfo()
    {
        string gpuName = SystemInfo.graphicsDeviceName;
        manager.refrences.gpuNameText.text = gpuName;
    }
    private void LoadData() {
        LoadDefualtDisplayResolution();
    }
    private void ApplyDisplayResolution(int index)
    {
        Resolution res = displayResolutions[index];

        Screen.SetResolution(res.width, res.height, Screen.fullScreenMode);
    }
    #endregion

    #region SettingsOptions
    private void DisplayResolutionOptions()
    {
        displayResolutions = new Resolution[]
        {
            new Resolution { width = 640, height = 480 },
            new Resolution { width = 800, height = 600 },
            new Resolution { width = 1024, height = 768 },
            new Resolution { width = 1280, height = 720 },
            new Resolution { width = 1280, height = 800 },
            new Resolution { width = 1366, height = 768 },
            new Resolution { width = 1440, height = 900 },
            new Resolution { width = 1600, height = 900 },
            new Resolution { width = 1680, height = 1050 },
            new Resolution { width = 1920, height = 1080 }

        };
        List<string> displayResolutionOptions = new List<string>();

        foreach (var resolution in displayResolutions)
        {
            displayResolutionOptions.Add($"{resolution.width} X {resolution.height}");
        }

        manager.refrences.DisplayResolutionDropdown.ClearOptions();

        manager.refrences.DisplayResolutionDropdown.AddOptions(displayResolutionOptions);
    }

    private void GetAllMonitors()
    {
        manager.refrences.DisplayMonitorDropdown.ClearOptions();
        List<string> monitors = new List<string>();
        for (int i = 0; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
            monitors.Add(Display.displays[i].ToString());
        }
        manager.refrences.DisplayMonitorDropdown.AddOptions(monitors);
    }
    #endregion
}