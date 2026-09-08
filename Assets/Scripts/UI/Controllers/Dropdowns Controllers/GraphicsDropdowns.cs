using System.Collections.Generic;
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
        PresetsOptions();
        TexturesOptions();
        ModelQualityOptions();
        AnisitropicFilterOptions();
        ShadowsOptions();
        ReflectionsOptions();
        AoOptions();

        LoadData();

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

    #region Options
    private void PresetsOptions()
    {
        manager.refrences.PresetDropdown.ClearOptions();

        List<string> options = new List<string>();
        foreach (GraphicsPreset preset in System.Enum.GetValues(typeof(GraphicsPreset)))
        {
            options.Add(preset.ToString());
        }

        manager.refrences.PresetDropdown.AddOptions(options);
    }
    private void TexturesOptions() { 
        manager.refrences.TexturesDropdown.ClearOptions();
        List<string> options = new List<string>();

        foreach (TexturesLevel texture in System.Enum.GetValues(typeof(TexturesLevel)))
        {
            options.Add(texture.ToString());
        }
        manager.refrences.TexturesDropdown.AddOptions(options);
    }
    private void ModelQualityOptions() { 
        manager.refrences.ModelQualityDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (ModelQualityLevel modelQuality in System.Enum.GetValues(typeof(ModelQualityLevel)))
        {
            options.Add(modelQuality.ToString());
        }
        manager.refrences.ModelQualityDropdown.AddOptions(options);
    }
    private void AnisitropicFilterOptions() {
        manager.refrences.AnistropicFilterDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (AnisotropicFilterLevel filter in System.Enum.GetValues(typeof(AnisotropicFilterLevel)))
        {
            options.Add(filter.ToString());
        }
       
        manager.refrences.AnistropicFilterDropdown.AddOptions(options);
    }
    private void ShadowsOptions() {
        manager.refrences.ShadowsDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (ShadowsLevel shadowsLevel in System.Enum.GetValues(typeof(ShadowsLevel)))
        {
            options.Add(shadowsLevel.ToString());
        }
        manager.refrences.ShadowsDropdown.AddOptions(options);
    }
    private void ReflectionsOptions() {
        manager.refrences.ReflectionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (ReflectionLevel reflectionLevel in System.Enum.GetValues(typeof(ReflectionLevel)))
        {
            options.Add(reflectionLevel.ToString());
        }
        manager.refrences.ReflectionsDropdown.AddOptions(options);
    }
    private void AoOptions() {
        manager.refrences.AmbientOcclusionDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (AmbientOcclusion AOLevel in System.Enum.GetValues(typeof(AmbientOcclusion)))
        {
            options.Add(AOLevel.ToString());
        }
        manager.refrences.AmbientOcclusionDropdown.AddOptions(options);
    }
    #endregion

    #region LoadDefualtData
    private void LoadDefaultGraphicsPreset() {
        int savedLevel = PlayerPrefs.GetInt(GameData.GRAPHICS_PRESET, (int)defaultPreset);
        if (PlayerPrefs.HasKey(GameData.GRAPHICS_PRESET))
        {
            manager.refrences.PresetDropdown.value = savedLevel;
            manager.refrences.PresetDropdown.RefreshShownValue();
        }
        else {
            manager.refrences.PresetDropdown.value = (int)defaultPreset;
            manager.refrences.PresetDropdown.RefreshShownValue();
        }
    }
    private void LoadDefaultTextureLevel() {
        int savedLevel = PlayerPrefs.GetInt(GameData.TEXTURE_LEVEL, (int)defaultTextureLevel);
        if (PlayerPrefs.HasKey(GameData.TEXTURE_LEVEL)) {
            manager.refrences.TexturesDropdown.value = savedLevel;
            manager.refrences.TexturesDropdown.RefreshShownValue();
        }
        else
        {
            manager.refrences.TexturesDropdown.value = (int)defaultTextureLevel;
            manager.refrences.TexturesDropdown.RefreshShownValue();
        }
    }
    private void LoadDefaultAnisitropicFilter()
    {
        int savedLevel = PlayerPrefs.GetInt(GameData.ANISITROPIC_FILTER, (int)defaultAnisitropicFilter);
        if (PlayerPrefs.HasKey(GameData.ANISITROPIC_FILTER))
        {
            manager.refrences.AnistropicFilterDropdown.value = savedLevel;
            manager.refrences.AnistropicFilterDropdown.RefreshShownValue();
        }
        else
        {
            manager.refrences.AnistropicFilterDropdown.value = (int)defaultAnisitropicFilter;
            manager.refrences.AnistropicFilterDropdown.RefreshShownValue();
        }
    }
    private void LoadDefaultModelLevel()
    {
        int savedLevel = PlayerPrefs.GetInt(GameData.MODEL_LEVEL, (int)defaultModelQualityLevel);
        if (PlayerPrefs.HasKey(GameData.MODEL_LEVEL))
        {
            manager.refrences.ModelQualityDropdown.value = savedLevel;
            manager.refrences.ModelQualityDropdown.RefreshShownValue();
        }
        else
        {
            manager.refrences.ModelQualityDropdown.value = (int)defaultModelQualityLevel;
            manager.refrences.ModelQualityDropdown.RefreshShownValue();
        }
    }
    private void LoadDefaultShadowsLevel()
    {
        int savedLevel = PlayerPrefs.GetInt(GameData.SHADOWS_LEVEL, (int)defaultShadowsLevel);
        if (PlayerPrefs.HasKey(GameData.SHADOWS_LEVEL))
        {
            manager.refrences.ShadowsDropdown.value = savedLevel;
            manager.refrences.ShadowsDropdown.RefreshShownValue();
        }
        else
        {
            manager.refrences.ShadowsDropdown.value = (int)defaultShadowsLevel;
            manager.refrences.ShadowsDropdown.RefreshShownValue();
        }
    }
    private void LoadDefaultReflectionLevel()
    {
        int savedLevel = PlayerPrefs.GetInt(GameData.REFLECTIONS_LEVEL, (int)defaultReflectionLevel);
        if (PlayerPrefs.HasKey(GameData.REFLECTIONS_LEVEL))
        {
            manager.refrences.ReflectionsDropdown.value = savedLevel;
            manager.refrences.ReflectionsDropdown.RefreshShownValue();
        }
        else
        {
            manager.refrences.ReflectionsDropdown.value = (int)defaultShadowsLevel;
            manager.refrences.ReflectionsDropdown.RefreshShownValue();
        }
    }
    private void LoadDefaultAmbientOcclusion()
    {
        int savedLevel = PlayerPrefs.GetInt(GameData.AMBIENT_OCCLUSION, (int)defaultAO);
        if (PlayerPrefs.HasKey(GameData.AMBIENT_OCCLUSION))
        {
            manager.refrences.AmbientOcclusionDropdown.value = savedLevel;
            manager.refrences.AmbientOcclusionDropdown.RefreshShownValue();
        }
        else
        {
            manager.refrences.AmbientOcclusionDropdown.value = (int)defaultAO;
            manager.refrences.AmbientOcclusionDropdown.RefreshShownValue();
        }
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
    private void LoadData() {
        LoadDefaultGraphicsPreset();
        LoadDefaultTextureLevel();
        LoadDefaultAnisitropicFilter();
        LoadDefaultModelLevel();
        LoadDefaultShadowsLevel();
        LoadDefaultReflectionLevel();
        LoadDefaultAmbientOcclusion();
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