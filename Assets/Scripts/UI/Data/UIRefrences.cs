using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRefrences : MonoBehaviour
{
    [Header("Panels")]
    public CanvasGroup MainMenuPanel;
    public CanvasGroup EnterMenuPanel;
    public CanvasGroup StoryPanel;
    public CanvasGroup NewGamePanel;
    public CanvasGroup LoadGamePanel;
    public CanvasGroup ExtrasPanel;
    public CanvasGroup OptionsPanel;
    public CanvasGroup QuitPanel;
    public CanvasGroup GameplayPanel;
    public CanvasGroup ControlsPanel;
    public CanvasGroup keyBindingsPanel;
    public CanvasGroup DisplayPanel;
    public CanvasGroup GraphicsPanel;
    public CanvasGroup AudioPanel;
    public CanvasGroup LanguagePanel;
    public CanvasGroup CreditsPanel;

    [Header("{MainMenu}Items")]
    public Button StoryButton;
    public Button ExtrasButton;
    public Button OptionsButton;
    public Button QuitDesktopButton;

    [Header("{EnterMenu}Items")]
    public TMP_Text EnterText;

    [Header("{StoryMenu}Items")]
    public Button NewGameButton;
    public Button LoadGameButton;

    [Header("{NewGame}Items")]
    public Button Slot1NewGameButton;
    public Button Slot2NewGameButton;
    public Button Slot3NewGameButton;
    public TMP_Text S1challangeText;
    public TMP_Text S2challangeText;
    public TMP_Text S3challangeText;
    public TMP_Text S1dateTimeText;
    public TMP_Text S2dateTimeText;
    public TMP_Text S3dateTimeText;

    [Header("{LoadGame}Items")]
    public Button Slot1LoadGameButton;
    public Button Slot2LoadGameButton;
    public Button Slot3LoadGameButton;
    public TMP_Text S1LoadchallangeText;
    public TMP_Text S2LoadchallangeText;
    public TMP_Text S3LoadchallangeText;
    public TMP_Text S1LoaddateTimeText;
    public TMP_Text S2LoaddateTimeText;
    public TMP_Text S3LoaddateTimeText;

    [Header("{ExtrasMenu}Items")]
    public Button CreditsButton;

    [Header("{OptionsMenu}Items")]
    public Button GameplayButton;
    public Button ControlsButton;
    public Button keyBindingsButton;
    public Button DisplayButton;
    public Button AdvancedGraphicsButton;
    public Button AudioButton;
    public Button LanguageButton;

    [Header("{QuitMenu}Items")]
    public Button YesButton;
    public Button NoButton;

    [Header("{GameplayMenu}Items")]
    public TMP_Dropdown ChallangeDropdown;
    public TMP_Dropdown GameplaySubtitlesDropdown;
    public TMP_Dropdown GameHintDropdown;
    public TMP_Dropdown TuturialsDropdown;
    public TMP_Dropdown PhotoModeDropdown;

    [Header("{ControlsMenu}Items")]
    public TMP_Text MouseSenitivityValueText;
    public TMP_Text CameraSenitivityValueText;
    public TMP_Text ControllerSenitivityValueText;
    public Slider MouseSenitivity;
    public Slider CameraSenitivity;
    public Slider ControllerSenitivity;

    [Header("{KeyBindings}Items")]

    [Header("{DisplayMenu}Items")]
    public TMP_Dropdown DisplayResolutionDropdown;
    public TMP_Text gpuNameText;
    public TMP_Dropdown DisplayMonitorDropdown;
    public TMP_Dropdown AspectRatioDropdown;
    public Toggle VsyncToggle;
    public Button ApplyDisplaySettingsButton;
    public Button ResetDisplaySettingsButton;

    [Header("{AdvancedGraphicsMenu}Items")]
    public TMP_Text EstimatedGraphicsUsageValueText;
    public TMP_Text TotalValueText;
    public Button GraphicsResetButton;
    public Button ApplyGraphicsButton;
    public TMP_Dropdown PresetDropdown;
    public TMP_Dropdown TexturesDropdown;
    public TMP_Dropdown ModelQualityDropdown;
    public TMP_Dropdown AnistropicFilterDropdown;
    public TMP_Dropdown ShadowsDropdown;
    public TMP_Dropdown ReflectionsDropdown;
    public TMP_Dropdown AmbientOcclusionDropdown;
    public Slider GraphicsUsageSlider;

    [Header("{AudioMenu}Items")]
    public TMP_Text WorldValueText;
    public TMP_Text EffectsValueText;
    public TMP_Text MusicValueText;
    public Slider WorldSlider;
    public Slider EffectsSlider;
    public Slider MusicSlider;
    public Button AudioResetButton;

    [Header("{Language}Items")]
    public TMP_Dropdown TextDropdown;
    public TMP_Dropdown LanguageSubtitlesDropdown;
    public TMP_Dropdown SpeechDropdown;
}