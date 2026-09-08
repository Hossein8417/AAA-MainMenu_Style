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
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from Quit menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.QuitPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
        Manager.refrences.YesButton.onClick.AddListener(OnQuitButtonClicked);
        Manager.refrences.NoButton.onClick.AddListener(OnQuitButtonNotClicked);
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.QuitPanel, false);
    }

    public void OnQuitButtonClicked() { 
        Application.Quit();
    }
    public void OnQuitButtonNotClicked() {
        Manager.ChangeState(States.MainMenu);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.MainMenu);
        }
    }
}
