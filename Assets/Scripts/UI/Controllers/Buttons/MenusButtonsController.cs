using UnityEngine;

public class MenusButtonsController : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private void Awake()
    {
        if (manager == null) return;
        ButtonsListeners();
    }

    #region On Clicked
    public void OnCreditsButtonPressed() => manager.ChangeState(States.Credits);
    public void OnYesQuitPressed() => Application.Quit(); 
    public void OnNoQuitPressed() => manager.ChangeState(States.MainMenu);
    public void OnControlsButtonPressed() => manager.ChangeState(States.Controls);
    public void OnKeyBindingsButtonPressed() => manager.ChangeState(States.keyBindings);
    public void OnAudioButtonPressed() => manager.ChangeState(States.Audio);
    public void OnGameplayButtonPressed() => manager.ChangeState(States.Gameplay);
    public void OnLanguageButtonPressed() => manager.ChangeState(States.Language);
    public void OnExtrasButtonPressed() => manager.ChangeState(States.Extrasmenu);
    public void OnOptionsButtonPressed() => manager.ChangeState(States.OptionsMenu);
    public void OnQuitButtonPressed() => manager.ChangeState(States.QuitMenu);
    #endregion

    #region General
    private void ButtonsListeners()
    {
        manager.refrences.CreditsButton.onClick.AddListener(OnCreditsButtonPressed);
        manager.refrences.YesButton.onClick.AddListener(OnYesQuitPressed);
        manager.refrences.NoButton.onClick.AddListener(OnNoQuitPressed);

        manager.refrences.GameplayButton.onClick.AddListener(OnGameplayButtonPressed);
        manager.refrences.ControlsButton.onClick.AddListener(OnControlsButtonPressed);
        manager.refrences.keyBindingsButton.onClick.AddListener(OnKeyBindingsButtonPressed);

        manager.refrences.AudioButton.onClick.AddListener(OnAudioButtonPressed);
        manager.refrences.LanguageButton.onClick.AddListener(OnLanguageButtonPressed);

        manager.refrences.ExtrasButton.onClick.AddListener(OnExtrasButtonPressed);
        manager.refrences.OptionsButton.onClick.AddListener(OnOptionsButtonPressed);
        manager.refrences.QuitDesktopButton.onClick.AddListener(OnQuitButtonPressed);
    }
    #endregion
}