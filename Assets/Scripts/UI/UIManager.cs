using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UIRefrences _refrences;
    public UIRefrences refrences => _refrences;

    [SerializeField]
    private Registry registry;

    private IState currentState;

    private void Awake()
    {
        if (_refrences == null) _refrences = GetComponent<UIRefrences>();
        if (registry == null) registry = GetComponent<Registry>();
        if (registry == null) registry = gameObject.AddComponent<Registry>();
    }

    private void Start()
    {
        InitializeDefaultState();
    }

    private void InitializeDefaultState()
    {
        currentState = registry.Get(States.EnterMenu);
        currentState.Show();
    }

    private void Update()
    {
        currentState?.UpdateState();
    }

    public void ChangeState(States newState)
    {
        if (currentState == null) return;

        currentState?.Hide();

        currentState = registry.Get(newState); ;

        currentState?.Show();
    }
}