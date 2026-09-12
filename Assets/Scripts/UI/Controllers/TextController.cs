using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private void Start()
    {
        GraphicsTotolMemoryDisplayer();
    }

    private void GraphicsTotolMemoryDisplayer() {
        if (manager == null || manager.refrences == null ||
            manager.refrences.TotalValueText == null) return;

        manager.refrences.TotalValueText.text = SystemInfo.graphicsMemorySize.ToString();
    }
}