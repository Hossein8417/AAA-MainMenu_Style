using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MainMenuAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private float scaleMultiplier = 1.2f;
    [SerializeField] private float duration = 0.3f;

    private Ease easeType = Ease.OutBack;

    private Vector3 originalScale;
    private Tween currentTween;
    private Vector3 newScale;
    void Start()
    {
        originalScale = transform.localScale;
        newScale = originalScale * scaleMultiplier;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        currentTween?.Kill();
        currentTween = transform.DOScale(newScale, duration).SetEase(easeType).SetUpdate(true);
    }
    public void OnPointerClick(PointerEventData eventData) {
        currentTween?.Kill();
        currentTween = transform.DOScale(originalScale, duration).SetEase(easeType).SetUpdate(true);
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