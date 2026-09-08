using UnityEngine;

public class EnterMenu : IState
{
    private UIManager Manager;

    public EnterMenu(UIManager manager)
    {
        Manager = manager;
    }
    public void Show() {
        if (Manager == null) {
            Debug.LogError("Can't access to ui manager from enter menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.EnterMenuPanel, true);

    }
    public void UpdateState() {
        CheckInput();
    }
    public void Hide() {
        Manager.panelsController.PanelActiver(Manager.refrences.EnterMenuPanel, false);
    }
    public void CheckInput() {
        if (Input.anyKeyDown)
        {
            Manager.ChangeState(States.MainMenu);
        }
    }
}