using System.Collections.Generic;
using UnityEngine;
public class Registry : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

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
    private void Awake()
    {
        if (manager == null) manager = GetComponent<UIManager>();
        InitializeStates();
    }

    public Dictionary<States, IState> states = new Dictionary<States, IState>();
    public void InitializeStates()
    {
        if (states.Count > 0) return;

        enterMenu = new EnterMenu(manager);
        mainMenu = new MainMenu(manager);
        storyMenu = new StoryMenu(manager);
        newGame = new NewGame(manager);
        loadGame = new LoadGame(manager);
        extrasMenu = new ExtrasMenu(manager);
        optionsMenu = new OptionsMenu(manager);
        quitMenu = new QuitMenu(manager);
        gameplayMenu = new GameplayMenu(manager);
        controlsMenu = new ControlsMenu(manager);
        keyBindingsMenu = new KeyBindingsMenu(manager);
        displayMenu = new DisplayMenu(manager);
        advancedGraphicsMenu = new AdvancedGraphicsMenu(manager);
        audioMenu = new AudioMenu(manager);
        languageMenu = new LanguageMenu(manager);
        creditsMenu = new CreditsMenu(manager);

        AddStatesRef();
    }
    private void AddStatesRef() {
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
        states.Add(States.Credits, creditsMenu);
    }
    public IState Get(States state)
    {
        return states[state];
    }
}