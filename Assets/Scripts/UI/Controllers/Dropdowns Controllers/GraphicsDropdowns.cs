using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GraphicsDropdowns : MonoBehaviour
{

    #region References

    [SerializeField] private UIManager manager;

    [Header("Default Settings")]

    [SerializeField] 
    private GraphicsPreset defaultPreset = GraphicsPreset.Low;

    [SerializeField] 
    private TexturesLevel defaultTextureLevel = TexturesLevel.Low;

    [SerializeField] 
    private ModelQualityLevel defaultModelQualityLevel = ModelQualityLevel.Economy;

    [SerializeField] 
    private ShadowsLevel defaultShadowsLevel = ShadowsLevel.Low;

    [SerializeField] 
    private ReflectionLevel defaultReflectionLevel = ReflectionLevel.Low;

    [SerializeField] 
    private AmbientOcclusion defaultAO = AmbientOcclusion.Disabled;

    [SerializeField] 
    private AnisotropicFilterLevel defaultAnisitropicFilter = AnisotropicFilterLevel.Disabled;

    #endregion

    private bool _isUpdatingFromPreset = false;

    private void Awake()
    {
        GraphicsOptions<GraphicsPreset>(manager.refrences.PresetDropdown);
        GraphicsOptions<TexturesLevel>(manager.refrences.TexturesDropdown);
        GraphicsOptions<ModelQualityLevel>(manager.refrences.ModelQualityDropdown);
        GraphicsOptions<AnisotropicFilterLevel>(manager.refrences.AnistropicFilterDropdown);
        GraphicsOptions<ShadowsLevel>(manager.refrences.ShadowsDropdown);
        GraphicsOptions<ReflectionLevel>(manager.refrences.ReflectionsDropdown);
        GraphicsOptions<AmbientOcclusion>(manager.refrences.AmbientOcclusionDropdown);

        LoadData(manager.refrences.PresetDropdown, GameData.GRAPHICS_PRESET, (int)defaultPreset);
        LoadData(manager.refrences.TexturesDropdown, GameData.TEXTURE_LEVEL, (int)defaultTextureLevel);
        LoadData(manager.refrences.ModelQualityDropdown, GameData.MODEL_LEVEL, (int)defaultModelQualityLevel);
        LoadData(manager.refrences.AnistropicFilterDropdown, GameData.ANISITROPIC_FILTER, (int)defaultAnisitropicFilter);
        LoadData(manager.refrences.ShadowsDropdown, GameData.SHADOWS_LEVEL, (int)defaultShadowsLevel);
        LoadData(manager.refrences.ReflectionsDropdown, GameData.REFLECTIONS_LEVEL, (int)defaultReflectionLevel);
        LoadData(manager.refrences.AmbientOcclusionDropdown, GameData.AMBIENT_OCCLUSION, (int)defaultAO);

        GraphicsListeners();
    }

    #region OnValuesChanged

    private void OnPresetChanged(int index)
    {
        if (_isUpdatingFromPreset) return;

        PresetSeter(index);

        GraphicsPresetsController.Instance.SetQuality(index);

        PlayerPrefs.SetInt(GameData.GRAPHICS_PRESET, index);
    }

    private void OnTextureChanged(int index)
    {
        if (_isUpdatingFromPreset) return;

        CustomSeter();

        ApplyGraphicsSettings();

        PlayerPrefs.SetInt(GameData.TEXTURE_LEVEL, index);
    }

    private void OnModelChanged(int index)
    {
        if (_isUpdatingFromPreset) return;

        CustomSeter();

        ApplyGraphicsSettings();

        PlayerPrefs.SetInt(GameData.MODEL_LEVEL, index);

    }

    private void OnAnisitropicFilterChanged(int index)
    {
        if (_isUpdatingFromPreset) return;

        CustomSeter();

        ApplyGraphicsSettings();

        PlayerPrefs.SetInt(GameData.ANISITROPIC_FILTER, index);
    }

    private void OnShadowChanged(int index)
    {
        if (_isUpdatingFromPreset) return;

        CustomSeter();

        ApplyGraphicsSettings();

        PlayerPrefs.SetInt(GameData.SHADOWS_LEVEL, index);
    }

    private void OnReflectionChanged(int index)
    {
        if (_isUpdatingFromPreset) return;

        CustomSeter();

        ApplyGraphicsSettings();

        PlayerPrefs.SetInt(GameData.REFLECTIONS_LEVEL, index);
    }

    private void OnAOChanged(int index)
    {
        if (_isUpdatingFromPreset) return;

        CustomSeter();

        ApplyGraphicsSettings();

        PlayerPrefs.SetInt(GameData.AMBIENT_OCCLUSION, index);
    }

    #endregion

    #region General

    private void GraphicsListeners()
    {
        manager.refrences.PresetDropdown.onValueChanged.AddListener(OnPresetChanged);
        manager.refrences.TexturesDropdown.onValueChanged.AddListener(OnTextureChanged);
        manager.refrences.ModelQualityDropdown.onValueChanged.AddListener(OnModelChanged);
        manager.refrences.AnistropicFilterDropdown.onValueChanged.AddListener(OnAnisitropicFilterChanged);
        manager.refrences.ShadowsDropdown.onValueChanged.AddListener(OnShadowChanged);
        manager.refrences.ReflectionsDropdown.onValueChanged.AddListener(OnReflectionChanged);
        manager.refrences.AmbientOcclusionDropdown.onValueChanged.AddListener(OnAOChanged);
    }

    private void GraphicsOptions<T>(TMP_Dropdown dropdown) where T : System.Enum
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
        dropdown.value = savedValue;
        dropdown.RefreshShownValue();
    }

    private void PresetSeter(int presetIndex)
    {
        _isUpdatingFromPreset = true;

        GraphicsPreset preset = (GraphicsPreset)presetIndex;

        SetDropdownValue(manager.refrences.TexturesDropdown, (int)GetTextureLevelFromPreset(preset));
        SetDropdownValue(manager.refrences.ModelQualityDropdown, (int)GetModelLevelFromPreset(preset));
        SetDropdownValue(manager.refrences.AnistropicFilterDropdown, (int)GetAnisoLevelFromPreset(preset));
        SetDropdownValue(manager.refrences.ShadowsDropdown, (int)GetShadowLevelFromPreset(preset));
        SetDropdownValue(manager.refrences.ReflectionsDropdown, (int)GetReflectionLevelFromPreset(preset));
        SetDropdownValue(manager.refrences.AmbientOcclusionDropdown, (int)GetAOLevelFromPreset(preset));

        _isUpdatingFromPreset = false;
    }

    private void SetDropdownValue(TMP_Dropdown dropdown, int value)
    {
        if (dropdown == null) return;
        dropdown.value = value;
        dropdown.RefreshShownValue();
    }

    private void CustomSeter()
    {
        _isUpdatingFromPreset = true;

        manager.refrences.PresetDropdown.value = (int)GraphicsPreset.Custom;
        manager.refrences.PresetDropdown.RefreshShownValue();

        _isUpdatingFromPreset = false;
    }

    private void ApplyGraphicsSettings()
    {
        //QualitySettings.masterTextureLimit = manager.refrences.TexturesDropdown.value;
    }

    #endregion

    #region Preset Mapping

    private TexturesLevel GetTextureLevelFromPreset(GraphicsPreset preset)
    {
        return preset switch
        {
            GraphicsPreset.VeryLow => TexturesLevel.Low,
            GraphicsPreset.Low => TexturesLevel.Normal,
            GraphicsPreset.Normal => TexturesLevel.High,
            GraphicsPreset.High => TexturesLevel.VeryHigh,
            _ => TexturesLevel.Low
        };
    }

    private ModelQualityLevel GetModelLevelFromPreset(GraphicsPreset preset)
    {
        return preset switch
        {
            GraphicsPreset.VeryLow => ModelQualityLevel.Low,
            GraphicsPreset.Low => ModelQualityLevel.Economy,
            GraphicsPreset.Normal => ModelQualityLevel.Normal,
            GraphicsPreset.High => ModelQualityLevel.Enhanced,
            _ => ModelQualityLevel.Economy
        };
    }

    private AnisotropicFilterLevel GetAnisoLevelFromPreset(GraphicsPreset preset)
    {
        return preset switch
        {
            GraphicsPreset.VeryLow => AnisotropicFilterLevel.Disabled,
            GraphicsPreset.Low => AnisotropicFilterLevel.Low,
            GraphicsPreset.Normal => AnisotropicFilterLevel.Normal,
            GraphicsPreset.High => AnisotropicFilterLevel.High,
            _ => AnisotropicFilterLevel.Low
        };
    }

    private ShadowsLevel GetShadowLevelFromPreset(GraphicsPreset preset)
    {
        return preset switch
        {
            GraphicsPreset.VeryLow => ShadowsLevel.Low,
            GraphicsPreset.Low => ShadowsLevel.Normal,
            GraphicsPreset.Normal => ShadowsLevel.High,
            GraphicsPreset.High => ShadowsLevel.VeryHigh,
            _ => ShadowsLevel.Normal
        };
    }

    private ReflectionLevel GetReflectionLevelFromPreset(GraphicsPreset preset)
    {
        return preset switch
        {
            GraphicsPreset.VeryLow => ReflectionLevel.Low,
            GraphicsPreset.Low => ReflectionLevel.Normal,
            GraphicsPreset.Normal => ReflectionLevel.High,
            GraphicsPreset.High => ReflectionLevel.VeryHigh,
            _ => ReflectionLevel.Normal
        };
    }

    private AmbientOcclusion GetAOLevelFromPreset(GraphicsPreset preset)
    {
        return preset switch
        {
            GraphicsPreset.VeryLow => AmbientOcclusion.Disabled,
            GraphicsPreset.Low => AmbientOcclusion.Low,
            GraphicsPreset.Normal => AmbientOcclusion.Normal,
            GraphicsPreset.High => AmbientOcclusion.High,
            _ => AmbientOcclusion.Disabled
        };
    }

    #endregion
}