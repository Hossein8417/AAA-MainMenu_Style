using UnityEngine;

public class TogglesControllers : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private void Awake()
    {
        LoadDefaultVsyncValue();

        TogglesListeners();
    }

    #region OnValuesChanged
    private void OnVsyncToggleValueChanged(bool isChanged)
    {
        ApplyVSync(isChanged);
        PlayerPrefs.SetInt(GameData.V_SYNC, isChanged ? 1 : 0);
    }
    #endregion

    #region LoadDefaults
    private void LoadDefaultVsyncValue()
    {
        if (PlayerPrefs.HasKey(GameData.V_SYNC))
        {
            bool isEnabled = PlayerPrefs.GetInt(GameData.V_SYNC, 1) == 1;
            manager.refrences.VsyncToggle.isOn = isEnabled;
            ApplyVSync(isEnabled);
        }
        else
        {
            manager.refrences.VsyncToggle.isOn = true;
            ApplyVSync(true);
        }
    }
    #endregion

    #region General
    private void ApplyVSync(bool isEnabled) { 
        QualitySettings.vSyncCount = isEnabled ? 1 : 0;
    }
    private void TogglesListeners()
    {
        manager.refrences.VsyncToggle.onValueChanged.AddListener(OnVsyncToggleValueChanged);
    }
    #endregion
}