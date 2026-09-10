using UnityEngine;

public class AudioMenu : IState
{
    private UIManager Manager;

    public AudioMenu(UIManager manager)
    {
        Manager = manager;
    }

    public void Show()
    {
        if (Manager == null) return;

        PanelsController.Instance.PanelActiver(Manager.refrences.AudioPanel, true);
    }
    public void UpdateState()
    {
        CheckInput();
    }
    public void Hide()
    {
        PanelsController.Instance.PanelActiver(Manager.refrences.AudioPanel, false);
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.ChangeState(States.OptionsMenu);
        }
    }
}
