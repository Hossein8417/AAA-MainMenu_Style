using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData _instance;
    public static GameData Instance
    {
        get
        {
            if (_instance == null) _instance.GetComponent<GameData>();
            return _instance;
        }
    }

    public const string CHALLANGE_MODE = "ChallangeMode";
    public const string DATA_AND_TIME = "DateAndTime";
    public const string SUBTITLE_MODE = "SubtitleMode";
    public const string GAME_HINT_MODE = "GameHintMode";
    public const string TUTORIALS_MODE = "TutorialsMode";
    public const string PHOTO_MODE = "PhotoMode";
    public const string MOUSE_SENTIVITY_VALUE = "MouseSentivityValue";
    public const string CAMERA_SENTIVITY_VALUE = "CameraSentivityValue";
    public const string CONTROLLER_SENTIVITY_VALUE = "ControllerSentivityValue";
    public const string DISPLAY_RESOLUTION = "DisplayResolution";
    public const string DISPLAY_MONITOR = "DisplayMonitor";
    public const string V_SYNC = "V-Sync";
    public const string ASPECTY_RATIO = "AspectRatio";
    public const string GRAPHICS_PRESET = "GraphicsPreset";
    public const string TEXTURE_LEVEL = "TextureLevel";
    public const string MODEL_LEVEL = "ModelLevel";
    public const string ANISITROPIC_FILTER = "AnisitropicFilter";
    public const string SHADOWS_LEVEL = "ShadowsLevel";
    public const string REFLECTIONS_LEVEL = "ReflectionsLevel";
    public const string AMBIENT_OCCLUSION = "AmbientOcclusion";
    public const string WORLD_AUDIO = "WorldAudio";
    public const string EFFECTS_AUDIO = "EffectsAudio";
    public const string MUSIC_AUDIO = "MusicAudio";
    public const string TEXT_LANGUAGE = "TextLanguage";
    public const string SUBTITLES_LANGUAGE = "SubtitlesLanguage";
    public const string SPEECH_LANGUAGE = "SpeechLanguage";
    public const string LANGUAGE_LOCALE = "LanguageLocale";
    public const string CURRENT_SLOT = "CurrentSlot";

    public string DateTime() {
        string date = System.DateTime.Now.ToString("yyyy/MM/dd");
        string time = System.DateTime.Now.ToString("HH/mm");
        return $"Date:{date}\nTime:{time}";
    }
    public static string SlotChallangeKey(int slot) => $"{CHALLANGE_MODE}_{slot}";
    public static string SlotDateTimeKey(int slot) => $"{DATA_AND_TIME}_{slot}";
    public static string SlotHasSaveKey(int slot) => $"HasSave_{slot}";

}