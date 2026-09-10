using UnityEngine;
public class UIManager : MonoBehaviour
{ 
    public UIRefrences refrences;

    IState currentState;
    private void Start()
    {
        Registry.Instance.InitializeStates();
        InitialDefaultState();
    }

    private void Update()
    {
        currentState.UpdateState();
    }
    
    public void ChangeState(States newState)
    {
        currentState.Hide();
       
        currentState = Get(newState);

        currentState.Show();
    }

    private void InitialDefaultState() {
        currentState = Get(States.EnterMenu);
        currentState.Show();
    }
    public IState Get(States state)
    {
        return Registry.Instance.states[state];
    }
}