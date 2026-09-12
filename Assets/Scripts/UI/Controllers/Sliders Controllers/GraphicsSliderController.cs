using UnityEngine;

public class GraphicsSliderController : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private void Start()
    {
        GraphicsMemoryDisplayer();
    }
    private void GraphicsMemoryDisplayer() {
        if (manager == null || manager.refrences == null ||
            manager.refrences.GraphicsUsageSlider == null) return;

        int vramMemory = SystemInfo.graphicsMemorySize;

        manager.refrences.GraphicsUsageSlider.minValue = 0;
        manager.refrences.GraphicsUsageSlider.maxValue = 12000;
        manager.refrences.GraphicsUsageSlider.value = vramMemory;
        manager.refrences.GraphicsUsageSlider.interactable = false;
    }
}
