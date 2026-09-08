using UnityEngine;

public class LanguageMenu : IState
{

    private UIManager Manager;

    public LanguageMenu(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from Language menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.LanguagePanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.LanguagePanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.OptionsMenu);
        }
    }
}