using UnityEngine;

public class QuitMenu : IState
{
    private UIManager Manager;
    public QuitMenu(UIManager manager)
    {
        Manager = manager;
    }
    public void Show()
    {
        if (Manager == null) return;

        PanelsController.Instance.PanelActiver(Manager.refrences.QuitPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        PanelsController.Instance.PanelActiver(Manager.refrences.QuitPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.MainMenu);
        }
    }
}
