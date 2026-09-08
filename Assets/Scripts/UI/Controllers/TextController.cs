using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private void Update()
    {
        GraphicsTotolMemoryDisplayer();
    }

    private void GraphicsTotolMemoryDisplayer() {
        string text = SystemInfo.graphicsMemorySize.ToString();
        manager.refrences.TotalValueText.text = text;
    }
}