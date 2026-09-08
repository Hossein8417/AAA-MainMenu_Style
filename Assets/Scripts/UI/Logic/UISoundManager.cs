using UnityEngine;

public class UISoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource clickSound;


    public static UISoundManager Instance;
    private void Awake()
    {
        if (Instance == null) { 
            Instance = this;
        }
        if (Instance != null) { 
            DontDestroyOnLoad(gameObject);
        }
    }
    public void UIClick() {
        clickSound.Play();
    }
}