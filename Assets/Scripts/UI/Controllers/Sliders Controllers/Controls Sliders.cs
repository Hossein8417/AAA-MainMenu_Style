using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        ControlsSliderSettingsSetter(manager.refrences.MouseSenitivity, 0.0f, 100.0f, true);
        ControlsSliderSettingsSetter(manager.refrences.CameraSenitivity, 0.0f, 100.0f, true);
        ControlsSliderSettingsSetter(manager.refrences.ControllerSenitivity, 0.0f, 100.0f, true);

        LoadData(manager.refrences.MouseSenitivity,
            manager.refrences.MouseSenitivityValueText, GameData.MOUSE_SENTIVITY_VALUE, (int)defaultMouseSentivityValue);
        LoadData(manager.refrences.CameraSenitivity,
            manager.refrences.CameraSenitivityValueText, GameData.CAMERA_SENTIVITY_VALUE, (int)defaultCameraSentivityValue);
        LoadData(manager.refrences.ControllerSenitivity,
            manager.refrences.ControllerSenitivityValueText, GameData.CONTROLLER_SENTIVITY_VALUE, (int)defaultControllerSentivityValue);

        ListenToSliders();
    }

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

    #region General
    private void ListenToSliders()
    {
        manager.refrences.MouseSenitivity.onValueChanged.AddListener(OnMouseSentivityValueChanged);
        manager.refrences.CameraSenitivity.onValueChanged.AddListener(OnCameraSentivityValueChanged);
        manager.refrences.ControllerSenitivity.onValueChanged.AddListener(OnControllerSentivityValueChanged);
    }
    private void ControlsSliderSettingsSetter(Slider slider, float minValue, float maxValue, bool isWholeNumber)
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.wholeNumbers = true;
    }
    private void LoadData(Slider slider, TMP_Text text, string prefId, int value)
    {
        float savedValue = PlayerPrefs.GetFloat(prefId, value);
        if (savedValue > 100.0f || savedValue < 0)
        {
            slider.value = value;
            text.text = value.ToString();
        }
        else
        {
            slider.value = savedValue;
            text.text = savedValue.ToString();
        }
    }
    #endregion
}