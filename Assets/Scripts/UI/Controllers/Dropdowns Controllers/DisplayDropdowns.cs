using System.Collections.Generic;
using UnityEngine;

public class DisplayDropdowns : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private Resolution[] displayResolutions;

    private const int DEFAULT_RESOLUTION_INDEX = 3;
    private const int DEFAULT_WIDTH = 1280;
    private const int DEFAULT_HEIGHT = 720;

    private void Awake()
    {
        if (manager == null) return;

        DisplayResolutionOptions();
        GetUserGPUInfo();
        GetAllMonitors();

        LoadData();
        DisplayListeners();
    }

    #region Load
    private void LoadDefaultDisplayResolution()
    {
        if (!PlayerPrefs.HasKey(GameData.DISPLAY_RESOLUTION))
        {
            Screen.SetResolution(DEFAULT_WIDTH, DEFAULT_HEIGHT, Screen.fullScreenMode);

            manager.refrences.DisplayResolutionDropdown.SetValueWithoutNotify(DEFAULT_RESOLUTION_INDEX);
            manager.refrences.DisplayResolutionDropdown.RefreshShownValue();

            PlayerPrefs.SetInt(GameData.DISPLAY_RESOLUTION, DEFAULT_RESOLUTION_INDEX);
            PlayerPrefs.Save();
        }
        else
        {
            int savedResolution = PlayerPrefs.GetInt(GameData.DISPLAY_RESOLUTION);

            if (savedResolution < 0 || savedResolution >= displayResolutions.Length)
                savedResolution = DEFAULT_RESOLUTION_INDEX;

            ApplyDisplayResolution(savedResolution);

            manager.refrences.DisplayResolutionDropdown.SetValueWithoutNotify(savedResolution);
            manager.refrences.DisplayResolutionDropdown.RefreshShownValue();
        }
    }
    #endregion

    #region OnValuesChanged
    private void OnDisplayResolutionChanged(int index)
    {
        ApplyDisplayResolution(index);
        PlayerPrefs.SetInt(GameData.DISPLAY_RESOLUTION, index);
        PlayerPrefs.Save();
    }

    private void OnMonitorChanged(int index)
    {
        if (index < 0 || index >= Display.displays.Length) return;

        Display.displays[index].Activate();
        PlayerPrefs.SetInt(GameData.DISPLAY_MONITOR, index);
        PlayerPrefs.Save();
    }
    #endregion

    #region General
    private void DisplayListeners()
    {
        manager.refrences.DisplayResolutionDropdown.onValueChanged.AddListener(OnDisplayResolutionChanged);
        manager.refrences.DisplayMonitorDropdown.onValueChanged.AddListener(OnMonitorChanged);
    }

    private void GetUserGPUInfo()
    {
        string gpuName = SystemInfo.graphicsDeviceName;
        if (manager.refrences.gpuNameText != null)
            manager.refrences.gpuNameText.text = gpuName;
    }

    private void LoadData()
    {
        LoadDefaultDisplayResolution();
    }

    private void ApplyDisplayResolution(int index)
    {
        if (displayResolutions == null || index < 0 || index >= displayResolutions.Length) return;

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
            monitors.Add($"Monitor {i + 1}: {Display.displays[i].systemWidth} X {Display.displays[i].systemHeight}");
        }

        manager.refrences.DisplayMonitorDropdown.AddOptions(monitors);
    }
    #endregion
}