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
        if (Manager == null) return;

        PanelsController.Instance.PanelActiver(Manager.refrences.StoryPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        PanelsController.Instance.PanelActiver(Manager.refrences.StoryPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.MainMenu);
        }
    }    
}