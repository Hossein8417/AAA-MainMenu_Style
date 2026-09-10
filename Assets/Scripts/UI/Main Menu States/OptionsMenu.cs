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
        if (Manager == null) return;

        PanelsController.Instance.PanelActiver(Manager.refrences.OptionsPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        PanelsController.Instance.PanelActiver(Manager.refrences.OptionsPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.MainMenu);
        }
    }
}