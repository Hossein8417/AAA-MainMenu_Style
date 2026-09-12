using UnityEngine;
public class GraphicsPresetsController : MonoBehaviour
{
    public static GraphicsPresetsController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SetQuality(int index) { 
        QualitySettings.SetQualityLevel(index, true);
    }

    public int GetQuality() { 
        return QualitySettings.GetQualityLevel();
    }
}