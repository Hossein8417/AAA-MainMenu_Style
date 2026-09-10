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
    private float defaultWorldAudioVolume;

    [SerializeField]
    private float defaultEffectsAudioVolume;

    [SerializeField]
    private float defaultMusicAudioVolume;

    private void Awake()
    {
        worldAudio.Play();
        musicAudio.Play();

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
        worldAudio.Stop();
        musicAudio.Stop();
    }


    #region OnValuesChanged Methods
    public void OnWorldAudioVolumeChanged(float value)
    {
        manager.refrences.WorldSlider.value = value;
        manager.refrences.WorldValueText.text = value.ToString();
        worldAudio.volume = value / 100;
        PlayerPrefs.SetFloat(GameData.WORLD_AUDIO, value);
        PlayerPrefs.Save();

    }
    public void OnEffectsAudioVolumeChanged(float value)
    {
        manager.refrences.EffectsSlider.value = value;
        manager.refrences.EffectsValueText.text = value.ToString();
        effectsAudio.volume = value / 100;
        PlayerPrefs.SetFloat(GameData.EFFECTS_AUDIO, value);
        PlayerPrefs.Save();
    }
    public void OnMusicAudioVolumeChanged(float value)
    {
        manager.refrences.MusicSlider.value = value;
        manager.refrences.MusicValueText.text = value.ToString();
        musicAudio.volume = value / 100;
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
    private void LoadData(Slider slider, TMP_Text text, AudioSource audioSource,string prefId, int value)
    {
        float savedValue = PlayerPrefs.GetFloat(prefId, value);
        if (savedValue > 100.0f || savedValue < 0)
        {
            audioSource.volume = value / 100;
            slider.value = value;
            text.text = value.ToString();
        }
        else
        {
            audioSource.volume = savedValue / 100;
            slider.value = savedValue;
            text.text = savedValue.ToString();
        }
    }
    #endregion
}