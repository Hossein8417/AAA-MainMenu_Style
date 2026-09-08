using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    #region Refrences
    public UIRefrences refrences;
    #endregion

    #region Instances
    IState currentState;
    #endregion

    #region States
    public EnterMenu enterMenu;
    public MainMenu mainMenu;
    public StoryMenu storyMenu;
    public NewGame newGame;
    public LoadGame loadGame;
    public ExtrasMenu extrasMenu;
    public OptionsMenu optionsMenu;
    public QuitMenu quitMenu;
    public GameplayMenu gameplayMenu;
    public ControlsMenu controlsMenu;
    public KeyBindingsMenu keyBindingsMenu;
    public DisplayMenu displayMenu;
    public AdvancedGraphicsMenu advancedGraphicsMenu;
    public AudioMenu audioMenu;
    public LanguageMenu languageMenu;
    public CreditsMenu creditsMenu;
    #endregion

    #region Controllers
    public PanelsController panelsController;
    #endregion

    public Dictionary<States, IState> states = new Dictionary<States, IState>();
    private void Awake()
    {   
        IntializeStates();
        InitialControllers();
        
    }

    private void Start()
    {
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
    private void InitialControllers() {
        panelsController = GetComponent<PanelsController>();
    }
    private void IntializeStates() {
        enterMenu = new EnterMenu(this);
        mainMenu = new MainMenu(this);
        storyMenu = new StoryMenu(this);
        newGame = new NewGame(this);
        loadGame = new LoadGame(this);
        extrasMenu = new ExtrasMenu(this);
        optionsMenu = new OptionsMenu(this);
        quitMenu = new QuitMenu(this);
        gameplayMenu = new GameplayMenu(this);
        controlsMenu = new ControlsMenu(this);
        keyBindingsMenu = new KeyBindingsMenu(this);
        displayMenu = new DisplayMenu(this);
        advancedGraphicsMenu = new AdvancedGraphicsMenu(this);
        audioMenu = new AudioMenu(this);
        languageMenu = new LanguageMenu(this);
        creditsMenu = new CreditsMenu(this);

        states.Add(States.EnterMenu, enterMenu);
        states.Add(States.MainMenu, mainMenu);
        states.Add(States.StoryMenu, storyMenu);
        states.Add(States.OptionsMenu, optionsMenu);
        states.Add(States.Extrasmenu, extrasMenu);
        states.Add(States.QuitMenu, quitMenu);
        states.Add(States.NewGame, newGame);
        states.Add(States.LoadGame, loadGame);
        states.Add(States.Gameplay, gameplayMenu);
        states.Add(States.Controls, controlsMenu);
        states.Add(States.keyBindings, keyBindingsMenu);
        states.Add(States.Display, displayMenu);
        states.Add(States.Graphics, advancedGraphicsMenu);
        states.Add(States.Audio, audioMenu);
        states.Add(States.Language, languageMenu);
        states.Add (States.Credits, creditsMenu);
    }
    private void InitialDefaultState() {
        currentState = Get(States.EnterMenu);
        currentState.Show();
    }
    public IState Get(States state)
    {
        return states[state];
    }
}