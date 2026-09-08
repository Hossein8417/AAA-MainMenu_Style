using UnityEngine;

public class PanelsController : MonoBehaviour
{
    public void PanelActiver(CanvasGroup panel, bool isActive) { 
        panel.gameObject.SetActive(isActive);
        panel.alpha = isActive ? 1 : 0;
    }
}