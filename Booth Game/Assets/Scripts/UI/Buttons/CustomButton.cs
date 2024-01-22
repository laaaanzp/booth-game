using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private string buttonText = "Menu Button";
    [SerializeField] private bool interactable = true;
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color hoverColor = Color.green;
    [SerializeField] private UnityEvent onClick;

    [Header("DO NOT TOUCH")]
    [SerializeField] private Image rightImage;
    [SerializeField] private Outline outline;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CanvasGroup canvasGroup;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!interactable) return;
        onClick?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!interactable) return;

        rightImage.color = hoverColor;
        outline.effectColor = hoverColor;
        text.color = hoverColor;

        LeanTween.scaleX(rightImage.gameObject, 2f, 0.1f).setIgnoreTimeScale(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!interactable) return;

        rightImage.color = defaultColor;
        outline.effectColor = defaultColor;
        text.color = defaultColor;

        LeanTween.scaleX(rightImage.gameObject, 1f, 0.1f).setIgnoreTimeScale(true);
    }

    void OnDisable()
    {
        rightImage.color = defaultColor;
        outline.effectColor = defaultColor;
        text.color = defaultColor;

        LeanTween.scaleX(rightImage.gameObject, 1f, 0.1f).setIgnoreTimeScale(true);
    }

    void OnValidate()
    {
        text.text = buttonText;
        text.color = defaultColor;
        rightImage.color = defaultColor;
        outline.effectColor = defaultColor;

        canvasGroup.alpha = interactable ? 1f : 0.75f;
    }

    public void SetInteractable(bool v)
    {
        interactable = v;
        canvasGroup.alpha = interactable ? 1f : 0.75f;
    }
}
