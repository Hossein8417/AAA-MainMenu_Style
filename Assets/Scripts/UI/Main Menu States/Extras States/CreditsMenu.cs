using UnityEngine;

public class CreditsMenu : IState
{
    private UIManager Manager;
    public CreditsMenu(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from Credits menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.CreditsPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.CreditsPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.Extrasmenu);
        }
    }
}