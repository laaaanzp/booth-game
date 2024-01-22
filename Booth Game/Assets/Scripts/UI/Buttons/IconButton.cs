using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IconButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private string buttonText = "•";
    [SerializeField] private bool interactable;
    [SerializeField] private UnityEvent onClick;

    [Header("DO NOT TOUCH")]
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

        outline.effectDistance = new Vector2(4, 4);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!interactable) return;

        outline.effectDistance = new Vector2(2, 2);
    }

    void OnDisable()
    {
        outline.effectDistance = new Vector2(2, 2);
    }

    void OnValidate()
    {
        text.text = buttonText;
        canvasGroup.alpha = interactable ? 1f : 0.75f;
    }

    public void SetInteractable(bool v)
    {
        interactable = v;
        canvasGroup.alpha = interactable ? 1f : 0.75f;
        outline.effectDistance = new Vector2(2, 2);
    }
}
