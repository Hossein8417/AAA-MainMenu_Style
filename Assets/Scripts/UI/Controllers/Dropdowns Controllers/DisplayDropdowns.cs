using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDropdowns : MonoBehaviour
{
    [SerializeField] 
    private UIManager manager;

    [SerializeField] 
    private bool savePreference = true;


    private Vector2Int[] aspectRatios;
    private Dictionary<string, List<Resolution>> resolutionMap;
    private List<Resolution> currentFilteredResolutions = new List<Resolution>();

    private const int DEFAULT_ASPECT_INDEX = 0; 
    private const int DEFAULT_RESOLUTION_INDEX = 4; 
    private const int DEFAULT_WIDTH = 1280;
    private const int DEFAULT_HEIGHT = 720;

    private void Awake()
    {
        if (manager == null) return;


        InitializeResolutionMap();

        DisplayAspectRatioOptions();

        GetUserGPUInfo();

        GetAllMonitors();

        LoadData();

        DisplayListeners();
    }

    #region Initialize Resolution Map

    private void InitializeResolutionMap()
    {
        resolutionMap = new Dictionary<string, List<Resolution>>
        {
            
            ["16:9"] = new List<Resolution>
            {
                new Resolution { width = 1280, height = 720 },
                new Resolution { width = 1366, height = 768 },
                new Resolution { width = 1600, height = 900 },
                new Resolution { width = 1920, height = 1080 },
                new Resolution { width = 2560, height = 1440 },
                new Resolution { width = 3840, height = 2160 },
            },

            
            ["16:10"] = new List<Resolution>
            {
                new Resolution { width = 1280, height = 800 },
                new Resolution { width = 1440, height = 900 },
                new Resolution { width = 1680, height = 1050 },
                new Resolution { width = 1920, height = 1200 },
                new Resolution { width = 2560, height = 1600 },
            },

            
            ["4:3"] = new List<Resolution>
            {
                new Resolution { width = 640, height = 480 },
                new Resolution { width = 800, height = 600 },
                new Resolution { width = 1024, height = 768 },
                new Resolution { width = 1280, height = 960 },
                new Resolution { width = 1600, height = 1200 },
            },

            
            ["5:4"] = new List<Resolution>
            {
                new Resolution { width = 1280, height = 1024 },
                new Resolution { width = 1600, height = 1280 },
            },

            
            ["21:9"] = new List<Resolution>
            {
                new Resolution { width = 2560, height = 1080 },
                new Resolution { width = 3440, height = 1440 },
                new Resolution { width = 3840, height = 1600 },
            },
        };
    }

    #endregion

    #region Options

    private void DisplayAspectRatioOptions()
    {
        
        aspectRatios = new Vector2Int[]
        {
            new Vector2Int(16, 9),
            new Vector2Int(16, 10),
            new Vector2Int(4, 3),
            new Vector2Int(5, 4),
            new Vector2Int(21, 9),
        };

        manager.refrences.AspectRatioDropdown.ClearOptions();

        List<string> aspects = new List<string>();
        foreach (var aspect in aspectRatios)
        {
            aspects.Add($"{aspect.x}:{aspect.y}");
        }

        manager.refrences.AspectRatioDropdown.AddOptions(aspects);
    }

    private void DisplayResolutionOptions(Vector2Int aspect)
    {
        string key = $"{aspect.x}:{aspect.y}";

        if (!resolutionMap.ContainsKey(key)) return;
       

        currentFilteredResolutions = resolutionMap[key];

        manager.refrences.DisplayResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        foreach (var res in currentFilteredResolutions)
        {
            options.Add($"{res.width} X {res.height}");
        }

        manager.refrences.DisplayResolutionDropdown.AddOptions(options);
    }

    private void GetAllMonitors()
    {
        manager.refrences.DisplayMonitorDropdown.ClearOptions();

        List<string> monitors = new List<string>();

        for (int i = 0; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
            monitors.Add($"Monitor {i + 1} is active");
        }

        manager.refrences.DisplayMonitorDropdown.AddOptions(monitors);
    }

    private void GetUserGPUInfo()
    {
        string gpuName = SystemInfo.graphicsDeviceName;
        if (manager.refrences.gpuNameText != null)
            manager.refrences.gpuNameText.text = gpuName;
    }

    #endregion

    #region Load Data

    private void LoadData()
    {
        LoadSavedAspect();
    }

    private void LoadSavedAspect()
    {
        int savedAspectIndex = DEFAULT_ASPECT_INDEX;

        if (savePreference && PlayerPrefs.HasKey(GameData.ASPECTY_RATIO))
        {
            savedAspectIndex = PlayerPrefs.GetInt(GameData.ASPECTY_RATIO, DEFAULT_ASPECT_INDEX);

            if (savedAspectIndex < 0 || savedAspectIndex >= aspectRatios.Length)
                savedAspectIndex = DEFAULT_ASPECT_INDEX;
        }
        else
        {
            savedAspectIndex = GetClosestAspectIndex();
        }

        manager.refrences.AspectRatioDropdown.SetValueWithoutNotify(savedAspectIndex);
        manager.refrences.AspectRatioDropdown.RefreshShownValue();

        
        DisplayResolutionOptions(aspectRatios[savedAspectIndex]);

        LoadSavedResolution();
    }

    private void LoadSavedResolution()
    {
        int savedResIndex = DEFAULT_RESOLUTION_INDEX;

        if (savePreference && PlayerPrefs.HasKey(GameData.DISPLAY_RESOLUTION))
        {
            savedResIndex = PlayerPrefs.GetInt(GameData.DISPLAY_RESOLUTION, DEFAULT_RESOLUTION_INDEX);
        }

        if (savedResIndex < 0 || savedResIndex >= currentFilteredResolutions.Count)
            savedResIndex = Mathf.Min(DEFAULT_RESOLUTION_INDEX, currentFilteredResolutions.Count - 1);

        manager.refrences.DisplayResolutionDropdown.SetValueWithoutNotify(savedResIndex);
        manager.refrences.DisplayResolutionDropdown.RefreshShownValue();

        ApplyDisplayResolution(savedResIndex);
    }

    #endregion

    #region OnValuesChanged

    private void OnAspectChanged(int index)
    {
        if (index < 0 || index >= aspectRatios.Length) return;

        Vector2Int selectedAspect = aspectRatios[index];

        DisplayResolutionOptions(selectedAspect);

        int resIndex = manager.refrences.DisplayResolutionDropdown.value;
        if (resIndex < 0 || resIndex >= currentFilteredResolutions.Count)
            resIndex = 0;

        manager.refrences.DisplayResolutionDropdown.SetValueWithoutNotify(resIndex);
        manager.refrences.DisplayResolutionDropdown.RefreshShownValue();
        ApplyDisplayResolution(resIndex);


        PlayerPrefs.SetInt(GameData.ASPECTY_RATIO, index);
        PlayerPrefs.SetInt(GameData.DISPLAY_RESOLUTION, resIndex);
    }

    private void OnDisplayResolutionChanged(int index)
    {
        if (index < 0 || index >= currentFilteredResolutions.Count) return;

        ApplyDisplayResolution(index);

        PlayerPrefs.SetInt(GameData.DISPLAY_RESOLUTION, index);
    }

    private void OnMonitorChanged(int index)
    {
        if (index < 0 || index >= Display.displays.Length) return;

        Display.displays[index].Activate();
        PlayerPrefs.SetInt(GameData.DISPLAY_MONITOR, index);

    }

    #endregion

    #region Apply

    private void ApplyDisplayResolution(int index)
    {
        if (currentFilteredResolutions == null ||
            index < 0 ||
            index >= currentFilteredResolutions.Count) return;

        Resolution res = currentFilteredResolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreenMode);

    }

    #endregion

    #region Helpers

    private int GetClosestAspectIndex()
    {
        float currentRatio = (float)Screen.width / Screen.height;
        int closestIndex = 0;
        float minDiff = float.MaxValue;

        for (int i = 0; i < aspectRatios.Length; i++)
        {
            float ratio = (float)aspectRatios[i].x / aspectRatios[i].y;
            float diff = Mathf.Abs(currentRatio - ratio);

            if (diff < minDiff)
            {
                minDiff = diff;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

    private void DisplayListeners()
    {
        manager.refrences.DisplayResolutionDropdown.onValueChanged.AddListener(OnDisplayResolutionChanged);
        manager.refrences.DisplayMonitorDropdown.onValueChanged.AddListener(OnMonitorChanged);
        manager.refrences.AspectRatioDropdown.onValueChanged.AddListener(OnAspectChanged);
    }

    #endregion

    #region Public Methods

    public Vector2Int GetCurrentAspectRatio()
    {
        int index = manager.refrences.AspectRatioDropdown.value;
        return aspectRatios[index];
    }

    public Resolution GetCurrentResolution()
    {
        int index = manager.refrences.DisplayResolutionDropdown.value;
        return currentFilteredResolutions[index];
    }

    #endregion
}