using UnityEngine;

public class StoryMenu : IState
{
    private UIManager Manager;
    
    public StoryMenu(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from story menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.StoryPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
        Manager.refrences.NewGameButton.onClick.AddListener(OnNewGameButtonPressed);
        Manager.refrences.LoadGameButton.onClick.AddListener(OnLoadGameButtonPressed);
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.StoryPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.MainMenu);
        }
    }
    public void OnNewGameButtonPressed()
    {
        Manager.ChangeState(States.NewGame);
    }
    public void OnLoadGameButtonPressed()
    {
        Manager.ChangeState(States.LoadGame);
    }
}
