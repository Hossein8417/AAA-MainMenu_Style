using UnityEngine;

public class EnterMenu : IState
{
    private UIManager Manager;

    public EnterMenu(UIManager manager)
    {
        Manager = manager;
    }
    public void Show() {
        if (Manager == null) return;
        
        PanelsController.Instance.PanelActiver(Manager.refrences.EnterMenuPanel, true);
    }
    public void UpdateState() {
        CheckInput();
    }
    public void Hide() {
        PanelsController.Instance.PanelActiver(Manager.refrences.EnterMenuPanel, false);
    }
    public void CheckInput() {
        if (Input.anyKeyDown)
        {
            Manager.ChangeState(States.MainMenu);
        }
    }
}