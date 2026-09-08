using UnityEngine;

public class OptionsMenu : IState
{
    private UIManager Manager;
    public OptionsMenu(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from Options menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.OptionsPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
        Manager.refrences.GameplayButton.onClick.AddListener(OnGameplayButtonPressed);
        Manager.refrences.ControlsButton.onClick.AddListener(OnControlsButtonPressed);
        Manager.refrences.keyBindingsButton.onClick.AddListener(OnKeyBindingsButtonPressed);
        Manager.refrences.DisplayButton.onClick.AddListener(OnDisplayButtonPressed);
        Manager.refrences.AdvancedGraphicsButton.onClick.AddListener(OnAdvancedGraphicsButtonPressed);
        Manager.refrences.AudioButton.onClick.AddListener(OnAudioButtonPressed);
        Manager.refrences.LanguageButton.onClick.AddListener(OnLanguageButtonPressed);
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.OptionsPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.MainMenu);
        }
    }
    public void OnControlsButtonPressed()
    {
        Manager.ChangeState(States.Controls);
    }
    public void OnKeyBindingsButtonPressed()
    {
        Manager.ChangeState(States.keyBindings);
    }
    public void OnDisplayButtonPressed()
    {
        Manager.ChangeState(States.Display);
    }
    public void OnAdvancedGraphicsButtonPressed()
    {
        Manager.ChangeState(States.Graphics);
    }
    public void OnAudioButtonPressed()
    {
        Manager.ChangeState(States.Audio);
    }
    public void OnGameplayButtonPressed()
    {
        Manager.ChangeState(States.Gameplay);
    }
    public void OnLanguageButtonPressed()
    {
        Manager.ChangeState(States.Language);
    }
}