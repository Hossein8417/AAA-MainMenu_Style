using UnityEngine;

public class UISoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource clickSound;


    public static UISoundManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void UIClick() {
        if (clickSound != null) clickSound.Play();
    }
}