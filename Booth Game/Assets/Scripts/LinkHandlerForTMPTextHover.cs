using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LinkHandlerForTMPTextHover : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpTextBox;
    [SerializeField] private RectTransform _textBoxRectTransform;

    [Header("Actions")]
    [SerializeField] private UnityEvent OnLinkHoverEnter;
    [SerializeField] private UnityEvent OnLinkHoverExit;

    public static string linkContent;

    private bool isTriggered;


    private void Update()
    {
        CheckForLinkAtMousePosition();
    }

    private void CheckForLinkAtMousePosition()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        bool isIntersectingRectTransform = TMP_TextUtilities.IsIntersectingRectTransform(_textBoxRectTransform, mousePosition, Camera.main);

        if (!isIntersectingRectTransform)
        {
            if (isTriggered) OnLinkHoverExit?.Invoke();

            isTriggered = false;
            return;
        }

        int intersectingLink = TMP_TextUtilities.FindIntersectingLink(_tmpTextBox, mousePosition, Camera.main);

        if (intersectingLink == -1)
        {
            if (isTriggered) OnLinkHoverExit?.Invoke();

            isTriggered = false;
            return;
        }

        if (isTriggered) return;

        TMP_LinkInfo linkInfo = _tmpTextBox.textInfo.linkInfo[intersectingLink];
        linkContent = linkInfo.GetLinkID();

        OnLinkHoverEnter?.Invoke();
        isTriggered = true;
    }

    public void Test(string v)
    {
        print(v);
    }

    public void Test()
    {
        print("Close");
    }
}