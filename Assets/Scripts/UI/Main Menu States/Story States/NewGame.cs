using UnityEngine;

public class NewGame : IState
{
    private UIManager Manager;

    public NewGame(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from NewGame menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.NewGamePanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.NewGamePanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.StoryMenu);
        }
    }
}
