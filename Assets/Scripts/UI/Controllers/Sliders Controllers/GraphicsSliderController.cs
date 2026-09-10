using UnityEngine;

public class GraphicsSliderController : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private void Update()
    {
        GraphicsMemoryDisplayer();
    }
    private void GraphicsMemoryDisplayer() {
        int VramMemory = SystemInfo.graphicsMemorySize;

        manager.refrences.GraphicsUsageSlider.minValue = 0;
        manager.refrences.GraphicsUsageSlider.maxValue = 12000;

        manager.refrences.GraphicsUsageSlider.value = VramMemory;
        manager.refrences.GraphicsUsageSlider.interactable = false;
    }
}
