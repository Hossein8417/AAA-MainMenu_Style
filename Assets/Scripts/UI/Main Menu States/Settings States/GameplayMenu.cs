using UnityEngine;

public class GameplayMenu : IState
{
    private UIManager Manager;

    public GameplayMenu(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from Gameplay menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.GameplayPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.GameplayPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.OptionsMenu);
        }
    } 
}
