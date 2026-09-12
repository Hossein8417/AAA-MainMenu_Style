using UnityEngine;

public class TogglesControllers : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private void Awake()
    {
        if (manager == null) return;

        LoadDefaultVsyncValue();
        TogglesListeners();
    }

    #region OnValuesChanged
    private void OnVsyncToggleValueChanged(bool isChanged)
    {
        ApplyVSync(isChanged);
        PlayerPrefs.SetInt(GameData.V_SYNC, isChanged ? 1 : 0);
        PlayerPrefs.Save();
    }
    #endregion

    #region Load
    private void LoadDefaultVsyncValue()
    {
        bool isEnabled = PlayerPrefs.GetInt(GameData.V_SYNC, 1) == 1;

        manager.refrences.VsyncToggle.SetIsOnWithoutNotify(isEnabled);
        ApplyVSync(isEnabled);
    }
    #endregion

    #region General
    private void ApplyVSync(bool isEnabled)
    {
        QualitySettings.vSyncCount = isEnabled ? 1 : 0;
    }

    private void TogglesListeners()
    {
        manager.refrences.VsyncToggle.onValueChanged.AddListener(OnVsyncToggleValueChanged);
    }
    #endregion
}