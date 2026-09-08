using UnityEngine;

public class KeyBindingsMenu : IState
{
    private UIManager Manager;

    public KeyBindingsMenu(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from Key Bindings menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.keyBindingsPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.keyBindingsPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.OptionsMenu);
        }
    }
}
