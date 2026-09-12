using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AudioSlidersControllers : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    [SerializeField]
    private AudioSource worldAudio;

    [SerializeField]
    private AudioSource effectsAudio;

    [SerializeField]
    private AudioSource musicAudio;

    [Header("Settings")]

    [SerializeField]
    private float defaultWorldAudioVolume = 100f;

    [SerializeField]
    private float defaultEffectsAudioVolume = 100f;

    [SerializeField]
    private float defaultMusicAudioVolume = 100f;

    private void Awake()
    {
        if (manager == null) return;

        if (worldAudio != null) worldAudio.Play();
        if (musicAudio != null) musicAudio.Play();

        AudiosSliderSettingsSetter(manager.refrences.WorldSlider, 0.0f, 100.0f, true);
        AudiosSliderSettingsSetter(manager.refrences.EffectsSlider, 0.0f, 100.0f, true);
        AudiosSliderSettingsSetter(manager.refrences.MusicSlider, 0.0f, 100.0f, true);

        LoadData(manager.refrences.WorldSlider,
            manager.refrences.WorldValueText,
            worldAudio,
            GameData.WORLD_AUDIO, (int)defaultWorldAudioVolume);

        LoadData(manager.refrences.EffectsSlider,
            manager.refrences.EffectsValueText, 
            effectsAudio,
            GameData.EFFECTS_AUDIO, (int)defaultEffectsAudioVolume);

        LoadData(manager.refrences.MusicSlider,
            manager.refrences.MusicValueText, 
            musicAudio,
            GameData.MUSIC_AUDIO, (int)defaultMusicAudioVolume);


        ListenToSliders();
    }
    private void OnDestroy()
    {
        if (worldAudio != null) worldAudio.Stop();
        if (musicAudio != null) musicAudio.Stop();
    }


    #region OnValuesChanged Methods
    public void OnWorldAudioVolumeChanged(float value)
    {
        manager.refrences.WorldValueText.text = value.ToString();

        worldAudio.volume = value / 100f;

        PlayerPrefs.SetFloat(GameData.WORLD_AUDIO, value);
        PlayerPrefs.Save();

    }
    public void OnEffectsAudioVolumeChanged(float value)
    {
        manager.refrences.EffectsValueText.text = value.ToString();

        effectsAudio.volume = value / 100f;

        PlayerPrefs.SetFloat(GameData.EFFECTS_AUDIO, value);
        PlayerPrefs.Save();
    }
    public void OnMusicAudioVolumeChanged(float value)
    {
        manager.refrences.MusicValueText.text = value.ToString();

        musicAudio.volume = value / 100f;

        PlayerPrefs.SetFloat(GameData.MUSIC_AUDIO, value);
        PlayerPrefs.Save();
    }
    #endregion

    #region General
    private void ListenToSliders()
    {
        manager.refrences.WorldSlider.onValueChanged.AddListener(OnWorldAudioVolumeChanged);
        manager.refrences.EffectsSlider.onValueChanged.AddListener(OnEffectsAudioVolumeChanged);
        manager.refrences.MusicSlider.onValueChanged.AddListener(OnMusicAudioVolumeChanged);
    }

    private void AudiosSliderSettingsSetter(Slider slider, float minValue, float maxValue, bool isWholeNumber)
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.wholeNumbers = true;
    }
    private void LoadData(Slider slider, TMP_Text text, AudioSource audioSource, string prefId, float defaultValue)
    {
        if (slider == null) return;

        float savedValue = PlayerPrefs.GetFloat(prefId, defaultValue);

        if (savedValue > 100f || savedValue < 0f)
            savedValue = defaultValue;

        if (audioSource != null) audioSource.volume = savedValue / 100f;

        slider.SetValueWithoutNotify(savedValue);

        if (text != null) text.text = Mathf.RoundToInt(savedValue).ToString();

    }
    #endregion
}