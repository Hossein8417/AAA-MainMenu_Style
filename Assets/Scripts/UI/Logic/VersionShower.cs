using UnityEngine;
using TMPro;
public class VersionShower : MonoBehaviour
{
    [SerializeField]
    private TMP_Text versionText;

    [SerializeField]
    private string versionString;


    private void Start()
    {
        versionText.text = versionString;
    }
}