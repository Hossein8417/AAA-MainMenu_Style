using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    //buttons controller must separate in multi button constrollers
    //if graphic settings are not equal to default or previous setting s =>
    //a pop up displayer shows to the player to apply settings with apply button
    [SerializeField]
    private UIManager manager;
    private void Awake()
    {
        LoadS1GameValues();
        LoadS2GameValues();
        LoadS3GameValues();

        AddButtonsListeners();
    }
    #region On Clicked Methods
    public void OnCreditsButtonPressed()
    {
        manager.ChangeState(States.Credits);
    }
    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
    public void OnQuitButtonNotClicked()
    {
        manager.ChangeState(States.MainMenu);
    }
    public void OnNewGameButtonPressed()
    {
        manager.ChangeState(States.NewGame);
    }
    public void OnLoadGameButtonPressed()
    {
        manager.ChangeState(States.LoadGame);
    }
    public void OnControlsButtonPressed()
    {
        manager.ChangeState(States.Controls);
    }
    public void OnKeyBindingsButtonPressed()
    {
        manager.ChangeState(States.keyBindings);
    }
    public void OnDisplayButtonPressed()
    {
        manager.ChangeState(States.Display);
    }
    public void OnAdvancedGraphicsButtonPressed()
    {
        manager.ChangeState(States.Graphics);
    }
    public void OnAudioButtonPressed()
    {
        manager.ChangeState(States.Audio);
    }
    public void OnGameplayButtonPressed()
    {
        manager.ChangeState(States.Gameplay);
    }
    public void OnLanguageButtonPressed()
    {
        manager.ChangeState(States.Language);
    }
    public void OnStoryButtonPressed()
    {
        manager.ChangeState(States.StoryMenu);
    }
    public void OnExtrasButtonPressed()
    {
        manager.ChangeState(States.Extrasmenu);
    }
    public void OnOptionsButtonPressed()
    {
        manager.ChangeState(States.OptionsMenu);
    }
    public void OnQuitButtonPressed()
    {
        manager.ChangeState(States.QuitMenu);
    }
    private void OnNewGame1Clicked() {
        GetInformationToButtons(manager.refrences.S1challangeText, manager.refrences.S1dateTimeText);
        SceneManager.LoadScene("Game");
    }
    private void OnNewGame2Clicked()
    {
        GetInformationToButtons(manager.refrences.S2challangeText, manager.refrences.S2dateTimeText);
        SceneManager.LoadScene("Game");
    }
    private void OnNewGame3Clicked()
    {
        GetInformationToButtons(manager.refrences.S3challangeText, manager.refrences.S3dateTimeText);
        SceneManager.LoadScene("Game");
    }
    private void OnLoadGame1Clicked() {
        GetLoadInformationToButtons();
        SceneManager.LoadScene("Game");
    }
    private void OnLoadGame2Clicked()
    {
        GetLoadInformationToButtons();
        SceneManager.LoadScene("Game");
    }
    private void OnLoadGame3Clicked()
    {
        GetLoadInformationToButtons();
        SceneManager.LoadScene("Game");
    }
    private void OnDisplayApplyButtonClicked()
    {
        PlayerPrefs.Save();
    }
    private void OnGraphicsApplyButtonClicked() { 
        PlayerPrefs.Save();
    }
    //new logic for better gameplay quality : when input handler time has arrived must create a logic for if apply button not clicked,ui shows a panel that settings are not confirmed and etc .... 
    private void OnDisplayResetClicked()
    {
        PlayerPrefs.DeleteKey(GameData.DISPLAY_RESOLUTION);
        PlayerPrefs.DeleteKey(GameData.V_SYNC);


        int screenWidth = 1280;
        int screenHeight = 720;
        int defaultResolutionIndex = 3;


        Screen.SetResolution(screenWidth, screenHeight, Screen.fullScreenMode);
        manager.refrences.DisplayResolutionDropdown.value = defaultResolutionIndex;
        manager.refrences.DisplayResolutionDropdown.RefreshShownValue();
        PlayerPrefs.GetInt(GameData.DISPLAY_RESOLUTION, defaultResolutionIndex);


        PlayerPrefs.GetInt(GameData.V_SYNC, 1);
    }
    private void OnGraphicsResetClicked() {
        PlayerPrefs.DeleteKey(GameData.GRAPHICS_PRESET);
        PlayerPrefs.DeleteKey(GameData.MODEL_LEVEL);
        PlayerPrefs.DeleteKey(GameData.ANISITROPIC_FILTER);
        PlayerPrefs.DeleteKey(GameData.TEXTURE_LEVEL);
        PlayerPrefs.DeleteKey(GameData.SHADOWS_LEVEL);
        PlayerPrefs.DeleteKey(GameData.REFLECTIONS_LEVEL);
        PlayerPrefs.DeleteKey(GameData.AMBIENT_OCCLUSION);

        //----
        QualitySettings.SetQualityLevel(1);

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

        PlayerPrefs.GetInt(GameData.GRAPHICS_PRESET, (int)GraphicsPreset.Low);
        PlayerPrefs.GetInt(GameData.TEXTURE_LEVEL, (int)TexturesLevel.Normal);
        PlayerPrefs.GetInt(GameData.MODEL_LEVEL, (int)ModelQualityLevel.Low);
        PlayerPrefs.GetInt(GameData.SHADOWS_LEVEL, (int)ShadowsLevel.Low);
        PlayerPrefs.GetInt(GameData.ANISITROPIC_FILTER, (int)AnisotropicFilterLevel.Low);
        PlayerPrefs.GetInt(GameData.AMBIENT_OCCLUSION, (int)AmbientOcclusion.Normal);
        PlayerPrefs.GetInt(GameData.REFLECTIONS_LEVEL, (int)ReflectionLevel.Low);
    }

    #endregion

    #region Load Methods
    private void LoadS1GameValues()
    {
        GetLoadValues(manager.refrences.S1challangeText, manager.refrences.S1dateTimeText,
            manager.refrences.S1LoadchallangeText, manager.refrences.S1LoaddateTimeText);

    }
    private void LoadS2GameValues()
    {
        GetLoadValues(manager.refrences.S2challangeText, manager.refrences.S2dateTimeText,
            manager.refrences.S2LoadchallangeText, manager.refrences.S2LoaddateTimeText);
    }
    private void LoadS3GameValues()
    {
        GetLoadValues(manager.refrences.S3challangeText, manager.refrences.S3dateTimeText, 
            manager.refrences.S3LoadchallangeText, manager.refrences.S3LoaddateTimeText);
    }
    #endregion

    #region General Methods
    private void AddButtonsListeners()
    {
        manager.refrences.CreditsButton.onClick.AddListener(OnCreditsButtonPressed);
        manager.refrences.YesButton.onClick.AddListener(OnQuitButtonClicked);
        manager.refrences.NoButton.onClick.AddListener(OnQuitButtonNotClicked);
        manager.refrences.NewGameButton.onClick.AddListener(OnNewGameButtonPressed);
        manager.refrences.LoadGameButton.onClick.AddListener(OnLoadGameButtonPressed);
        manager.refrences.GameplayButton.onClick.AddListener(OnGameplayButtonPressed);
        manager.refrences.ControlsButton.onClick.AddListener(OnControlsButtonPressed);
        manager.refrences.keyBindingsButton.onClick.AddListener(OnKeyBindingsButtonPressed);
        manager.refrences.DisplayButton.onClick.AddListener(OnDisplayButtonPressed);
        manager.refrences.AdvancedGraphicsButton.onClick.AddListener(OnAdvancedGraphicsButtonPressed);
        manager.refrences.AudioButton.onClick.AddListener(OnAudioButtonPressed);
        manager.refrences.LanguageButton.onClick.AddListener(OnLanguageButtonPressed);
        manager.refrences.StoryButton.onClick.AddListener(OnStoryButtonPressed);
        manager.refrences.ExtrasButton.onClick.AddListener(OnExtrasButtonPressed);
        manager.refrences.OptionsButton.onClick.AddListener(OnOptionsButtonPressed);
        manager.refrences.QuitDesktopButton.onClick.AddListener(OnQuitButtonPressed);
        manager.refrences.Slot1NewGameButton.onClick.AddListener(OnNewGame1Clicked);
        manager.refrences.Slot2NewGameButton.onClick.AddListener(OnNewGame2Clicked);
        manager.refrences.Slot3NewGameButton.onClick.AddListener(OnNewGame3Clicked);
        manager.refrences.Slot1LoadGameButton.onClick.AddListener(OnLoadGame1Clicked);
        manager.refrences.Slot2LoadGameButton.onClick.AddListener(OnLoadGame2Clicked);
        manager.refrences.Slot3LoadGameButton.onClick.AddListener(OnLoadGame3Clicked);
        manager.refrences.ApplyDisplaySettingsButton.onClick.AddListener(OnDisplayApplyButtonClicked);
        manager.refrences.ResetDisplaySettingsButton.onClick.AddListener(OnDisplayResetClicked);
        manager.refrences.ApplyGraphicsButton.onClick.AddListener(OnGraphicsApplyButtonClicked);
        manager.refrences.GraphicsResetButton.onClick.AddListener(OnGraphicsResetClicked);
    }
    private void GetInformationToButtons(TMP_Text slotChallangeText, TMP_Text slotDataTimeText) {
        int savedValue = PlayerPrefs.GetInt(GameData.CHALLANGE_MODE);

        ChallangeLevel level = (ChallangeLevel)savedValue;

        slotChallangeText.text = $"Challange Mode : {level}";

        string dateTime = GameData.Instance.DateTime();

        PlayerPrefs.SetString(GameData.DATA_AND_TIME, dateTime);

        slotDataTimeText.text = $"Date & Time : {dateTime}";
    }
    private void GetLoadInformationToButtons() {
        int savedChallange = PlayerPrefs.GetInt(GameData.CHALLANGE_MODE);
    }
    private void GetLoadValues(TMP_Text slotChallangeText, TMP_Text slotDataTimeText
        ,TMP_Text slotLoadChallangeText, TMP_Text slotLoadDataTimeText) {

        if (slotChallangeText.text != string.Empty && slotDataTimeText.text != string.Empty)
        {
            slotLoadChallangeText.text = slotChallangeText.text;
            slotLoadDataTimeText.text = slotDataTimeText.text;
        }
        else slotLoadChallangeText.text = "Challange Mode: ";
    }
    #endregion
}