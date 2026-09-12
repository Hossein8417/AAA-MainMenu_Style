using UnityEngine;

public class DisplayGraphicsButtons : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private void Awake()
    {
        if (manager == null) return;
        ButtonsListeners();
    }

    #region On Clicked
    public void OnDisplayButtonPressed() => manager.ChangeState(States.Display);
    public void OnAdvancedGraphicsButtonPressed() => manager.ChangeState(States.Graphics);

    private void OnDisplayApplyButtonClicked() => PlayerPrefs.Save();
    private void OnGraphicsApplyButtonClicked() => PlayerPrefs.Save();

    private void OnDisplayResetClicked()
    {
        PlayerPrefs.DeleteKey(GameData.DISPLAY_RESOLUTION);
        PlayerPrefs.DeleteKey(GameData.V_SYNC);

        const int screenWidth = 1280;
        const int screenHeight = 720;
        const int defaultResolutionIndex = 3;

        Screen.SetResolution(screenWidth, screenHeight, Screen.fullScreenMode);

        manager.refrences.DisplayResolutionDropdown.value = defaultResolutionIndex;
        manager.refrences.DisplayResolutionDropdown.RefreshShownValue();

        manager.refrences.VsyncToggle.isOn = true;

        PlayerPrefs.SetInt(GameData.DISPLAY_RESOLUTION, defaultResolutionIndex);
        PlayerPrefs.SetInt(GameData.V_SYNC, 1);
        PlayerPrefs.Save();
    }

    private void OnGraphicsResetClicked()
    {
        PlayerPrefs.DeleteKey(GameData.GRAPHICS_PRESET);
        PlayerPrefs.DeleteKey(GameData.MODEL_LEVEL);
        PlayerPrefs.DeleteKey(GameData.ANISITROPIC_FILTER);
        PlayerPrefs.DeleteKey(GameData.TEXTURE_LEVEL);
        PlayerPrefs.DeleteKey(GameData.SHADOWS_LEVEL);
        PlayerPrefs.DeleteKey(GameData.REFLECTIONS_LEVEL);
        PlayerPrefs.DeleteKey(GameData.AMBIENT_OCCLUSION);

        GraphicsPresetsController.Instance.SetQuality((int)GraphicsPreset.Low);

        manager.refrences.PresetDropdown.value = (int)GraphicsPreset.Low;
        manager.refrences.PresetDropdown.RefreshShownValue();

        manager.refrences.ModelQualityDropdown.value = (int)ModelQualityLevel.Low;
        manager.refrences.ModelQualityDropdown.RefreshShownValue();

        manager.refrences.TexturesDropdown.value = (int)TexturesLevel.Normal;
        manager.refrences.TexturesDropdown.RefreshShownValue();

        manager.refrences.AnistropicFilterDropdown.value = (int)AnisotropicFilterLevel.Low;
        manager.refrences.AnistropicFilterDropdown.RefreshShownValue();

        manager.refrences.ShadowsDropdown.value = (int)ShadowsLevel.Low;
        manager.refrences.ShadowsDropdown.RefreshShownValue();

        manager.refrences.ReflectionsDropdown.value = (int)ReflectionLevel.Low;
        manager.refrences.ReflectionsDropdown.RefreshShownValue();

        manager.refrences.AmbientOcclusionDropdown.value = (int)AmbientOcclusion.Normal;
        manager.refrences.AmbientOcclusionDropdown.RefreshShownValue();

        PlayerPrefs.SetInt(GameData.GRAPHICS_PRESET, (int)GraphicsPreset.Low);
        PlayerPrefs.SetInt(GameData.TEXTURE_LEVEL, (int)TexturesLevel.Normal);
        PlayerPrefs.SetInt(GameData.MODEL_LEVEL, (int)ModelQualityLevel.Low);
        PlayerPrefs.SetInt(GameData.SHADOWS_LEVEL, (int)ShadowsLevel.Low);
        PlayerPrefs.SetInt(GameData.ANISITROPIC_FILTER, (int)AnisotropicFilterLevel.Low);
        PlayerPrefs.SetInt(GameData.AMBIENT_OCCLUSION, (int)AmbientOcclusion.Normal);
        PlayerPrefs.SetInt(GameData.REFLECTIONS_LEVEL, (int)ReflectionLevel.Low);
        PlayerPrefs.Save();
    }
    #endregion

    #region General
    private void ButtonsListeners()
    {
        manager.refrences.DisplayButton.onClick.AddListener(OnDisplayButtonPressed);
        manager.refrences.AdvancedGraphicsButton.onClick.AddListener(OnAdvancedGraphicsButtonPressed);
        manager.refrences.ApplyDisplaySettingsButton.onClick.AddListener(OnDisplayApplyButtonClicked);
        manager.refrences.ResetDisplaySettingsButton.onClick.AddListener(OnDisplayResetClicked);
        manager.refrences.ApplyGraphicsButton.onClick.AddListener(OnGraphicsApplyButtonClicked);
        manager.refrences.GraphicsResetButton.onClick.AddListener(OnGraphicsResetClicked);
    }
    #endregion
}