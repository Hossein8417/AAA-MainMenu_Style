using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MainMenuAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float scaleMultiplier = 1.2f;
    [SerializeField] private float duration = 0.3f;

    private Ease easeType = Ease.OutBack;

    private Vector3 originalScale;
    private Tween currentTween;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentTween?.Kill();

        currentTween = transform.DOScale(originalScale * scaleMultiplier, duration).SetEase(easeType).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        currentTween?.Kill();

        currentTween = transform.DOScale(originalScale, duration).SetEase(easeType).SetUpdate(true);
    }

    void OnDestroy()
    {
        currentTween?.Kill();
    }
}