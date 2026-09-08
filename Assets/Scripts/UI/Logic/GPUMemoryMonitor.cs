using UnityEngine;
using Unity.Profiling;
public class GPUMemoryMonitor : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    private ProfilerRecorder gfxMemoryRecorder;

    private void OnEnable()
    {
        ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Gfx Used Memory");
    }

    private void Update()
    {
        if (!gfxMemoryRecorder.Valid)
        {
            manager.refrences.EstimatedGraphicsUsageValueText.text = "N/A";
            return;
        }

        float mb = gfxMemoryRecorder.LastValue / (1024f * 1024f);

        manager.refrences.EstimatedGraphicsUsageValueText.text = $"{mb:F0} MB";
    }

    private void OnDisable() { 
        gfxMemoryRecorder.Dispose();
    }
}
