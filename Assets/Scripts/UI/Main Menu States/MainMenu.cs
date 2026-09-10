using UnityEngine;

public class MainMenu : IState
{
    private UIManager Manager;
    
    public MainMenu(UIManager manager)
    {
        Manager = manager;  
    }

    public void Show()
    {
        if (Manager == null) return; 

        PanelsController.Instance.PanelActiver(Manager.refrences.MainMenuPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        PanelsController.Instance.PanelActiver(Manager.refrences.MainMenuPanel, false);
    }

    public void CheckInput() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Manager.ChangeState(States.QuitMenu);
        }
    }
}