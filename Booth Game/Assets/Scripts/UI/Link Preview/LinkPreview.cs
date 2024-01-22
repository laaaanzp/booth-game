using TMPro;
using UnityEngine;

public class LinkPreview : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI linkText;
    [SerializeField] private CanvasGroup canvasGroup;


    public void OnLinkHoverEnter()
    {
        linkText.text = LinkHandlerForTMPTextHover.linkContent;
        canvasGroup.alpha = 1f;
    }

    public void OnLinkHoverExit()
    {
        canvasGroup.alpha = 0f;
    }
}
