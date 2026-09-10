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
        if (Manager == null) return;

        PanelsController.Instance.PanelActiver(Manager.refrences.LoadGamePanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        PanelsController.Instance.PanelActiver(Manager.refrences.LoadGamePanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.StoryMenu);
        }
    }
}