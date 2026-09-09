using DG.Tweening;
using UnityEngine;
public class EnterMenuAnimations : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    [SerializeField] private float blinkDuration = 2f;

    private Ease easeType = Ease.InOutSine;

    private Tween blinkTween;
    
    void Awake()
    {
        if (manager != null) StartBlinking();
    }

    public void StartBlinking()
    {
        StopBlinking();

        blinkTween = manager.refrences.EnterText.DOFade(0f, blinkDuration / 2f).SetLoops(-1, LoopType.Yoyo).SetEase(easeType).SetUpdate(true);
    }

    public void StopBlinking()
    {
        if (blinkTween != null)
        {
            blinkTween.Kill();
            blinkTween = null;
        }

       
        manager.refrences.EnterText.DOFade(1f, 0.1f);
    }

    void OnDestroy()
    {
        StopBlinking();
    }
}