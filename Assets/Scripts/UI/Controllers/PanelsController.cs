using UnityEngine;

public class PanelsController : MonoBehaviour
{
    public static PanelsController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != this )
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);

            if (Instance == null)
            {
                Instance = this;
            }
        }
        Instance = this;
    }
    public void PanelActiver(CanvasGroup panel, bool isActive) { 
        panel.gameObject.SetActive(isActive);
        panel.alpha = isActive ? 1 : 0;
    }
}