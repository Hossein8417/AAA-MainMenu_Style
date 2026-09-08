using UnityEngine;

public class ClickPlayer : MonoBehaviour
{
    private void Update()
    {
        if(Input.anyKeyDown) UISoundManager.Instance.UIClick();
    }
}