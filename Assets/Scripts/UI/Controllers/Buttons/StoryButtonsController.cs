using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryButtonsController : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private const int SLOT_COUNT = 3;

    private void Awake()
    {
        if (manager == null) return;

        LoadData();
        ButtonsListeners();
    }

    #region OnClick
    public void OnNewGameButtonPressed()
    {
        manager.ChangeState(States.NewGame);
    }

    public void OnLoadGameButtonPressed()
    {
        manager.ChangeState(States.LoadGame);
    }

    public void OnStoryButtonPressed()
    {
        manager.ChangeState(States.StoryMenu);
    }

    private void OnNewGame1Clicked() => StartNewGame(1);
    private void OnNewGame2Clicked() => StartNewGame(2);
    private void OnNewGame3Clicked() => StartNewGame(3);

    private void OnLoadGame1Clicked() => LoadGameFromSlot(1);
    private void OnLoadGame2Clicked() => LoadGameFromSlot(2);
    private void OnLoadGame3Clicked() => LoadGameFromSlot(3);
    #endregion

    #region General
    private void ButtonsListeners()
    {
        manager.refrences.StoryButton.onClick.AddListener(OnStoryButtonPressed);
        manager.refrences.NewGameButton.onClick.AddListener(OnNewGameButtonPressed);
        manager.refrences.LoadGameButton.onClick.AddListener(OnLoadGameButtonPressed);
        manager.refrences.Slot1NewGameButton.onClick.AddListener(OnNewGame1Clicked);
        manager.refrences.Slot2NewGameButton.onClick.AddListener(OnNewGame2Clicked);
        manager.refrences.Slot3NewGameButton.onClick.AddListener(OnNewGame3Clicked);
        manager.refrences.Slot1LoadGameButton.onClick.AddListener(OnLoadGame1Clicked);
        manager.refrences.Slot2LoadGameButton.onClick.AddListener(OnLoadGame2Clicked);
        manager.refrences.Slot3LoadGameButton.onClick.AddListener(OnLoadGame3Clicked);
    }

    private void LoadData()
    {
        RefreshSlotUI(1,
            manager.refrences.S1challangeText, manager.refrences.S1dateTimeText,
            manager.refrences.S1LoadchallangeText, manager.refrences.S1LoaddateTimeText);

        RefreshSlotUI(2,
            manager.refrences.S2challangeText, manager.refrences.S2dateTimeText,
            manager.refrences.S2LoadchallangeText, manager.refrences.S2LoaddateTimeText);

        RefreshSlotUI(3,
            manager.refrences.S3challangeText, manager.refrences.S3dateTimeText,
            manager.refrences.S3LoadchallangeText, manager.refrences.S3LoaddateTimeText);
    }

    private void RefreshSlotUI(int slot,
        TMP_Text slotChallangeText, TMP_Text slotDataTimeText,
        TMP_Text slotLoadChallangeText, TMP_Text slotLoadDataTimeText)
    {
        bool hasSave = PlayerPrefs.GetInt(GameData.SlotHasSaveKey(slot), 0) == 1;

        if (!hasSave)
        {
            slotChallangeText.text = string.Empty;
            slotDataTimeText.text = string.Empty;
            slotLoadChallangeText.text = "Challange Mode: ";
            slotLoadDataTimeText.text = string.Empty;
            return;
        }

        int challangeValue = PlayerPrefs.GetInt(GameData.SlotChallangeKey(slot), 0);
        ChallangeLevel level = (ChallangeLevel)challangeValue;
        string dateTime = PlayerPrefs.GetString(GameData.SlotDateTimeKey(slot), string.Empty);

        slotChallangeText.text = $"Challange Mode : {level}";
        slotDataTimeText.text = $"Date & Time : {dateTime}";

        slotLoadChallangeText.text = slotChallangeText.text;
        slotLoadDataTimeText.text = slotDataTimeText.text;
    }

    private void StartNewGame(int slot)
    {
        if (slot < 1 || slot > SLOT_COUNT) return;

        int savedValue = PlayerPrefs.GetInt(GameData.CHALLANGE_MODE, 0);
        string dateTime = GameData.Instance.DateTime();

        PlayerPrefs.SetInt(GameData.SlotChallangeKey(slot), savedValue);
        PlayerPrefs.SetString(GameData.SlotDateTimeKey(slot), dateTime);
        PlayerPrefs.SetInt(GameData.SlotHasSaveKey(slot), 1);
        PlayerPrefs.SetInt(GameData.CURRENT_SLOT, slot);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Game");
    }

    private void LoadGameFromSlot(int slot)
    {
        if (slot < 1 || slot > SLOT_COUNT) return;

        bool hasSave = PlayerPrefs.GetInt(GameData.SlotHasSaveKey(slot), 0) == 1;
        if (!hasSave)
        {
            Debug.LogWarning($"[Story] Slot {slot} has no save!");
            return;
        }

        PlayerPrefs.SetInt(GameData.CURRENT_SLOT, slot);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Game");
    }
    #endregion
}