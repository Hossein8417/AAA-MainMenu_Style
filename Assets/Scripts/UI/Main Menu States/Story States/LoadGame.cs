using UnityEngine;

public class LoadGame : IState
{
    private UIManager Manager;

    public LoadGame(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from LoadGame menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.LoadGamePanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.LoadGamePanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.StoryMenu);
        }
    }
}
