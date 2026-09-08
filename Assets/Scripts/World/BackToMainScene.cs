using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMainScene : MonoBehaviour
{
    [SerializeField]
    private Button button;
    void Update()
    {
        button.onClick.AddListener(OnClick);
    }
    
    private void OnClick() {
        SceneManager.LoadScene("Main Menu");
    }
}
