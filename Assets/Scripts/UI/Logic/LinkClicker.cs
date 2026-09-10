using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMP_Text))]
public class LinkClicker : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        TMP_Text textComponent = GetComponent<TMP_Text>();

        int linkIndex = TMP_TextUtilities.FindIntersectingLink(
            textComponent,
            eventData.position,
            eventData.enterEventCamera
        );

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = textComponent.textInfo.linkInfo[linkIndex];
            string linkId = linkInfo.GetLinkID();
            if (linkId.StartsWith("http"))
            {
                Application.OpenURL(linkId);
            }
            if (!linkId.StartsWith("http")) return;
        }
    }
}
