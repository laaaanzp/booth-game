using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Selection : MonoBehaviour
{
    public string value
    {
        get
        {
            if (items.Length > 0)
                return items[currentIndex];
            else
                return string.Empty;
        }
    }

    [SerializeField] private string[] items;
    [SerializeField] private UnityEvent onValueChanged;

    [Header("DO NOT TOUCH")]
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private IconButton previousIconButton;
    [SerializeField] private IconButton nextIconButton;

    private int currentIndex = 0;
    
    void OnValidate()
    {
        if (items.Length == 0)
        {
            text.text = "";
            previousIconButton.SetInteractable(false);
            nextIconButton.SetInteractable(false);
            return;
        }

        text.text = items[currentIndex];
        previousIconButton.SetInteractable(currentIndex != 0);
        nextIconButton.SetInteractable(currentIndex < items.Length - 1);
    }

    public void Previous()
    {
        currentIndex--;
        onValueChanged?.Invoke();
        UpdateDisplay();
    }

    public void Next()
    {
        currentIndex++;
        onValueChanged?.Invoke();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        text.text = items[currentIndex];
        previousIconButton.SetInteractable(currentIndex != 0);
        nextIconButton.SetInteractable(currentIndex < items.Length - 1);
    }
}
