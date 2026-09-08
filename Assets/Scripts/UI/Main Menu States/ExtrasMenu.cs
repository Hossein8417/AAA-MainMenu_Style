using UnityEngine;

public class ExtrasMenu : IState
{
    private UIManager Manager;   
    public ExtrasMenu(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null)
        {
            Debug.LogError("Cant access to ui manager from Extras menu");
            return;
        }
        Manager.panelsController.PanelActiver(Manager.refrences.ExtrasPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
        Manager.refrences.CreditsButton.onClick.AddListener(OnCreditsButtonPressed);
    }
    public void Hide()
    {
        Manager.panelsController.PanelActiver(Manager.refrences.ExtrasPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.MainMenu);
        }
    }
    public void OnCreditsButtonPressed()
    {
        Manager.ChangeState(States.Credits);
    }
}