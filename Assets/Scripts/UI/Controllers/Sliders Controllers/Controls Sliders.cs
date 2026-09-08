using UnityEngine;

public class ControlsSliders : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    [Header("Settings")]

    [SerializeField]
    private float defaultMouseSentivityValue;

    [SerializeField]
    private float defaultCameraSentivityValue;

    [SerializeField]
    private float defaultControllerSentivityValue;

    private void Awake()
    {
        MouseValueSettings();
        CameraValueSettings();
        ControllerValueSettings();

        LoadData();

        ListenToSliders();
    }


    #region LoadDefaultSettings
    private void LoadDefaultMouseSentivityValue()
    {
        float savedValue = PlayerPrefs.GetFloat(GameData.MOUSE_SENTIVITY_VALUE, defaultMouseSentivityValue);
        if (savedValue > 100.0f || savedValue < 0)
        {
            manager.refrences.MouseSenitivity.value = defaultMouseSentivityValue;
            manager.refrences.MouseSenitivityValueText.text = defaultMouseSentivityValue.ToString();
        }
        else
        { 
            manager.refrences.MouseSenitivity.value = savedValue;
            manager.refrences.MouseSenitivityValueText.text = savedValue.ToString();
        }

    }
    private void LoadDefaultCameraSentivityValue()
    {
        float savedValue = PlayerPrefs.GetFloat(GameData.CAMERA_SENTIVITY_VALUE, defaultCameraSentivityValue);
        if (savedValue > 100.0f || savedValue < 0)
        {
            manager.refrences.CameraSenitivity.value = defaultCameraSentivityValue;
            manager.refrences.CameraSenitivityValueText.text = defaultCameraSentivityValue.ToString();
        }
        else
        {
            manager.refrences.CameraSenitivity.value = savedValue;
            manager.refrences.CameraSenitivityValueText.text = savedValue.ToString();
        }
    }
    private void LoadDefaultControllerSentivityValue()
    {
        float savedValue = PlayerPrefs.GetFloat(GameData.CONTROLLER_SENTIVITY_VALUE, defaultControllerSentivityValue);
        if (savedValue > 100.0f || savedValue < 0)
        {
            manager.refrences.ControllerSenitivity.value = defaultControllerSentivityValue;
            manager.refrences.ControllerSenitivityValueText.text = defaultControllerSentivityValue.ToString();
        }
        else
        {
            manager.refrences.ControllerSenitivity.value = savedValue;
            manager.refrences.ControllerSenitivityValueText.text = savedValue.ToString();
        }
    }
    #endregion 

    #region OnValuesChanged Methods
    public void OnMouseSentivityValueChanged(float value)
    {
        manager.refrences.MouseSenitivityValueText.text = value.ToString();
        PlayerPrefs.SetFloat(GameData.MOUSE_SENTIVITY_VALUE, value);
        PlayerPrefs.Save();

    }
    public void OnCameraSentivityValueChanged(float value)
    {
        manager.refrences.CameraSenitivityValueText.text = value.ToString();
        PlayerPrefs.SetFloat(GameData.CAMERA_SENTIVITY_VALUE, value);
        PlayerPrefs.Save();
    }
    public void OnControllerSentivityValueChanged(float value)
    {
        manager.refrences.ControllerSenitivityValueText.text = value.ToString();
        PlayerPrefs.SetFloat(GameData.CONTROLLER_SENTIVITY_VALUE, value);
        PlayerPrefs.Save();
    }
    #endregion

    #region Settings
    public void MouseValueSettings()
    {
        manager.refrences.MouseSenitivity.minValue = 0.0f;
        manager.refrences.MouseSenitivity.maxValue = 100.0f;
        manager.refrences.MouseSenitivity.wholeNumbers = true;
    }
    public void CameraValueSettings()
    {
        manager.refrences.CameraSenitivity.minValue = 0.0f;
        manager.refrences.CameraSenitivity.maxValue = 100.0f;
        manager.refrences.CameraSenitivity.wholeNumbers = true;
    }
    public void ControllerValueSettings()
    {
        manager.refrences.ControllerSenitivity.minValue = 0.0f;
        manager.refrences.ControllerSenitivity.maxValue = 100.0f;
        manager.refrences.ControllerSenitivity.wholeNumbers = true;
    }
    #endregion

    #region General
    private void ListenToSliders()
    {
        manager.refrences.MouseSenitivity.onValueChanged.AddListener(OnMouseSentivityValueChanged);
        manager.refrences.CameraSenitivity.onValueChanged.AddListener(OnCameraSentivityValueChanged);
        manager.refrences.ControllerSenitivity.onValueChanged.AddListener(OnControllerSentivityValueChanged);
    }

    private void LoadData()
    {
        LoadDefaultMouseSentivityValue();
        LoadDefaultCameraSentivityValue();
        LoadDefaultControllerSentivityValue();
    }
    #endregion
}