using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphicsDropdowns : MonoBehaviour
{
    #region References

    [SerializeField]
    private UIManager manager;

    [Header("Default Settings")]
    [SerializeField]
    private GraphicsPreset defaultPreset;

    [SerializeField]
    private TexturesLevel defaultTextureLevel;

    [SerializeField]
    private ModelQualityLevel defaultModelQualityLevel;

    [SerializeField]
    private ShadowsLevel defaultShadowsLevel;

    [SerializeField]
    private ReflectionLevel defaultReflectionLevel;

    [SerializeField]
    private AmbientOcclusion defaultAO;

    [SerializeField]
    private AnisotropicFilterLevel defaultAnisitropicFilter; 
    #endregion
    private void Awake()
    {
        GraphicsOptions<GraphicsPreset>(manager.refrences.PresetDropdown);
        GraphicsOptions<TexturesLevel>(manager.refrences.TexturesDropdown);
        GraphicsOptions<ModelQualityLevel>(manager.refrences.ModelQualityDropdown);
        GraphicsOptions<AnisotropicFilterLevel>(manager.refrences.AnistropicFilterDropdown);
        GraphicsOptions<ShadowsLevel>(manager.refrences.ShadowsDropdown);
        GraphicsOptions<ReflectionLevel>(manager.refrences.ReflectionsDropdown);
        GraphicsOptions<AmbientOcclusion>(manager.refrences.AmbientOcclusionDropdown);

        LoadData<GraphicsPreset>(manager.refrences.PresetDropdown, GameData.GRAPHICS_PRESET, (int)defaultPreset);
        LoadData<TexturesLevel>(manager.refrences.TexturesDropdown, GameData.TEXTURE_LEVEL, (int)defaultTextureLevel);
        LoadData<ModelQualityLevel>(manager.refrences.ModelQualityDropdown, GameData.MODEL_LEVEL, (int)defaultModelQualityLevel);
        LoadData<AnisotropicFilterLevel>(manager.refrences.AnistropicFilterDropdown, GameData.ANISITROPIC_FILTER, (int)defaultAnisitropicFilter);
        LoadData<ShadowsLevel>(manager.refrences.ShadowsDropdown, GameData.SHADOWS_LEVEL, (int)defaultShadowsLevel);
        LoadData<ReflectionLevel>(manager.refrences.ReflectionsDropdown, GameData.REFLECTIONS_LEVEL, (int)defaultReflectionLevel);
        LoadData<AmbientOcclusion>(manager.refrences.AmbientOcclusionDropdown, GameData.AMBIENT_OCCLUSION, (int)defaultAO);

        GraphicsListeners();   
    }

    #region OnValuesChanged
    private void OnPresetChanged(int index)
    {
        SettingApplier();

        GraphicsPresetsController.Instance.SetQuality(index);

        PlayerPrefs.SetInt(GameData.GRAPHICS_PRESET, index); 
    }
    private void OnTextureChanged(int index) {
        CustomPresetSetter();
        PlayerPrefs.SetInt(GameData.TEXTURE_LEVEL, index);
    }
    private void OnModelChanged(int index) {
        CustomPresetSetter();
        PlayerPrefs.SetInt(GameData.MODEL_LEVEL, index);
    }
    private void OnAnisitropicFilterChanged(int index) {
        CustomPresetSetter();
        PlayerPrefs.SetInt(GameData.ANISITROPIC_FILTER, index);
    }
    private void OnShadowChanged(int index)
    {
        CustomPresetSetter();
        PlayerPrefs.SetInt(GameData.SHADOWS_LEVEL, index);
    }
    private void OnReflectionChanged(int index)
    {
        CustomPresetSetter();
        PlayerPrefs.SetInt(GameData.REFLECTIONS_LEVEL, index);
    }
    private void OnAOChanged(int index)
    {
        CustomPresetSetter();
        PlayerPrefs.SetInt(GameData.AMBIENT_OCCLUSION, index);
    }


    #endregion

    #region General
    private void GraphicsListeners() {
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
    private void CustomPresetSetter() {
        manager.refrences.PresetDropdown.value = (int)GraphicsPreset.Custom;
        manager.refrences.PresetDropdown.RefreshShownValue();
    }

    //whean refactor time arrived, this logic must be beter architecture
    private void SettingApplier() { 
        if (manager.refrences.PresetDropdown.value == (int)GraphicsPreset.VeryLow)
        {
            manager.refrences.PresetDropdown.value = (int)GraphicsPreset.VeryLow;
            manager.refrences.PresetDropdown.RefreshShownValue();

            manager.refrences.TexturesDropdown.value = (int)TexturesLevel.Low;
            manager.refrences.TexturesDropdown.RefreshShownValue();

            manager.refrences.ModelQualityDropdown.value = (int)ModelQualityLevel.Low;
            manager.refrences.ModelQualityDropdown.RefreshShownValue();

            manager.refrences.AnistropicFilterDropdown.value = (int)AnisotropicFilterLevel.Disabled;
            manager.refrences.AnistropicFilterDropdown.RefreshShownValue();

            manager.refrences.ShadowsDropdown.value = (int)ShadowsLevel.Low;
            manager.refrences.ShadowsDropdown.RefreshShownValue();

            manager.refrences.ReflectionsDropdown.value = (int)ReflectionLevel.Low;
            manager.refrences.ReflectionsDropdown.RefreshShownValue();

            manager.refrences.AmbientOcclusionDropdown.value = (int)AmbientOcclusion.Disabled;
            manager.refrences.AmbientOcclusionDropdown.RefreshShownValue();
        }
        else if (manager.refrences.PresetDropdown.value == (int)GraphicsPreset.Low)
        {
            manager.refrences.PresetDropdown.value = (int)GraphicsPreset.Low;
            manager.refrences.PresetDropdown.RefreshShownValue();

            manager.refrences.TexturesDropdown.value = (int)TexturesLevel.Low;
            manager.refrences.TexturesDropdown.RefreshShownValue();

            manager.refrences.ModelQualityDropdown.value = (int)ModelQualityLevel.Low;
            manager.refrences.ModelQualityDropdown.RefreshShownValue();

            manager.refrences.AnistropicFilterDropdown.value = (int)AnisotropicFilterLevel.Low;
            manager.refrences.AnistropicFilterDropdown.RefreshShownValue();

            manager.refrences.ShadowsDropdown.value = (int)ShadowsLevel.Normal;
            manager.refrences.ShadowsDropdown.RefreshShownValue();

            manager.refrences.ReflectionsDropdown.value = (int)ReflectionLevel.Low;
            manager.refrences.ReflectionsDropdown.RefreshShownValue();

            manager.refrences.AmbientOcclusionDropdown.value = (int)AmbientOcclusion.Low;
            manager.refrences.AmbientOcclusionDropdown.RefreshShownValue();
        }
        else if (manager.refrences.PresetDropdown.value == (int)GraphicsPreset.Normal)
        {
            manager.refrences.PresetDropdown.value = (int)GraphicsPreset.Normal;
            manager.refrences.PresetDropdown.RefreshShownValue();

            manager.refrences.TexturesDropdown.value = (int)TexturesLevel.Normal;
            manager.refrences.TexturesDropdown.RefreshShownValue();

            manager.refrences.ModelQualityDropdown.value = (int)ModelQualityLevel.Normal;
            manager.refrences.ModelQualityDropdown.RefreshShownValue();

            manager.refrences.AnistropicFilterDropdown.value = (int)AnisotropicFilterLevel.Normal;
            manager.refrences.AnistropicFilterDropdown.RefreshShownValue();

            manager.refrences.ShadowsDropdown.value = (int)ShadowsLevel.High;
            manager.refrences.ShadowsDropdown.RefreshShownValue();

            manager.refrences.ReflectionsDropdown.value = (int)ReflectionLevel.Normal;
            manager.refrences.ReflectionsDropdown.RefreshShownValue();

            manager.refrences.AmbientOcclusionDropdown.value = (int)AmbientOcclusion.Normal;
            manager.refrences.AmbientOcclusionDropdown.RefreshShownValue();
        }
        else if (manager.refrences.PresetDropdown.value == (int)GraphicsPreset.High)
        {
            manager.refrences.PresetDropdown.value = (int)GraphicsPreset.High;
            manager.refrences.PresetDropdown.RefreshShownValue();

            manager.refrences.TexturesDropdown.value = (int)TexturesLevel.VeryHigh;
            manager.refrences.TexturesDropdown.RefreshShownValue();

            manager.refrences.ModelQualityDropdown.value = (int)ModelQualityLevel.Enhanced;
            manager.refrences.ModelQualityDropdown.RefreshShownValue();

            manager.refrences.AnistropicFilterDropdown.value = (int)AnisotropicFilterLevel.High;
            manager.refrences.AnistropicFilterDropdown.RefreshShownValue();

            manager.refrences.ShadowsDropdown.value = (int)ShadowsLevel.VeryHigh;
            manager.refrences.ShadowsDropdown.RefreshShownValue();

            manager.refrences.ReflectionsDropdown.value = (int)ReflectionLevel.High;
            manager.refrences.ReflectionsDropdown.RefreshShownValue();

            manager.refrences.AmbientOcclusionDropdown.value = (int)AmbientOcclusion.High;
            manager.refrences.AmbientOcclusionDropdown.RefreshShownValue();
        }
    }
    #endregion
}