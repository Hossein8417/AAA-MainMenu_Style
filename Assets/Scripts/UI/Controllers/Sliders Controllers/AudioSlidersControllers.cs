using UnityEngine;

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

        WorldVolumeSettings();
        EffectsVolumeSettings();
        MusicVolumeSettings();

        LoadData();

        ListenToSliders();
    }
    private void OnDestroy()
    {
        worldAudio.Stop();
        musicAudio.Stop();
    }

    #region LoadDefaultSettings
    private void LoadDefaultWorldAudioVolume()
    {
        float savedValue = PlayerPrefs.GetFloat(GameData.WORLD_AUDIO, defaultWorldAudioVolume);
        if (savedValue > 100.0f || savedValue < 0)
        {
            worldAudio.volume = defaultWorldAudioVolume / 100;
            manager.refrences.WorldSlider.value = defaultWorldAudioVolume;
            manager.refrences.WorldValueText.text = defaultWorldAudioVolume.ToString();
        }
        else
        {
            worldAudio.volume = savedValue / 100;
            manager.refrences.WorldSlider.value = savedValue;
            manager.refrences.WorldValueText.text = savedValue.ToString();
        }

    }
    private void LoadDefaultEffectsAudioVolume()
    {
        float savedValue = PlayerPrefs.GetFloat(GameData.EFFECTS_AUDIO, defaultEffectsAudioVolume);
        if (savedValue > 100.0f || savedValue < 0)
        {
            effectsAudio.volume = defaultEffectsAudioVolume / 100;
            manager.refrences.EffectsSlider.value = defaultEffectsAudioVolume;
            manager.refrences.EffectsValueText.text = defaultEffectsAudioVolume.ToString();
        }
        else
        {
            effectsAudio.volume = savedValue / 100;
            manager.refrences.EffectsSlider.value = savedValue;
            manager.refrences.EffectsValueText.text = savedValue.ToString();
        }
    }
    private void LoadDefaultMusicAudioVolume()
    {
        float savedValue = PlayerPrefs.GetFloat(GameData.MUSIC_AUDIO, defaultMusicAudioVolume);
        if (savedValue > 100.0f || savedValue < 0)
        {
            musicAudio.volume = defaultMusicAudioVolume / 100;
            manager.refrences.MusicSlider.value = defaultMusicAudioVolume;
            manager.refrences.MusicValueText.text = defaultMusicAudioVolume.ToString();
        }
        else
        {
            musicAudio.volume = savedValue / 100;
            manager.refrences.MusicSlider.value = savedValue;
            manager.refrences.MusicValueText.text = savedValue.ToString();
        }
    }
    #endregion 

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

    #region Settings
    public void WorldVolumeSettings()
    {
        manager.refrences.WorldSlider.minValue = 0.0f;
        manager.refrences.WorldSlider.maxValue = 100.0f;
        manager.refrences.WorldSlider.wholeNumbers = true;
    }
    public void EffectsVolumeSettings()
    {
        manager.refrences.EffectsSlider.minValue = 0.0f;
        manager.refrences.EffectsSlider.maxValue = 100.0f;
        manager.refrences.EffectsSlider.wholeNumbers = true;
    }
    public void MusicVolumeSettings()
    {
        manager.refrences.MusicSlider.minValue = 0.0f;
        manager.refrences.MusicSlider.maxValue = 100.0f;
        manager.refrences.MusicSlider.wholeNumbers = true;
    }
    #endregion

    #region General
    private void ListenToSliders()
    {
        manager.refrences.WorldSlider.onValueChanged.AddListener(OnWorldAudioVolumeChanged);
        manager.refrences.EffectsSlider.onValueChanged.AddListener(OnEffectsAudioVolumeChanged);
        manager.refrences.MusicSlider.onValueChanged.AddListener(OnMusicAudioVolumeChanged);
    }

    private void LoadData()
    {
        LoadDefaultWorldAudioVolume();
        LoadDefaultEffectsAudioVolume();
        LoadDefaultMusicAudioVolume();
    }
    #endregion
}