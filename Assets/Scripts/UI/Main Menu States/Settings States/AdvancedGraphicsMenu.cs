using UnityEngine;

public class AdvancedGraphicsMenu : IState
{
    private UIManager Manager;

    public AdvancedGraphicsMenu(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from Graphics menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.GraphicsPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.GraphicsPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.OptionsMenu);
        }
    }
}
