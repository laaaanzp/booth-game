using TMPro;
using UnityEngine;

public class NumericUpDown : MonoBehaviour
{
    [SerializeField] private int max = 1;
    [SerializeField] private int min = 0;

    public int value = 0;

    [Header("DO NOT TOUCH")]
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private IconButton decrementIconButton;
    [SerializeField] private IconButton incrementIconButton;


    void Awake()
    {
        ValidateButtons();

        valueText.text = value.ToString();
    }

    void OnValidate()
    {
        if (min > max)
        {
            max = 1;
            min = 0;
            Debug.LogError("Maximum can't be lower than minimum.");
        }

        if (value < min) value = min;
        if (value > max) value = max;

        // ValidateButtons();

        valueText.text = value.ToString();
    }

    public void Decrement()
    {
        value--;
        valueText.text = value.ToString();
        ValidateButtons();
    }

    public void Incremenet()
    {
        value++;
        valueText.text = value.ToString();
        ValidateButtons();
    }

    private void ValidateButtons()
    {
        print($"Value({value}) > Min({min}): {value < min}");
        print($"Value({value}) > Max({max}): {value > max}");
        decrementIconButton.SetInteractable(value > min);
        incrementIconButton.SetInteractable(value < max);
    }
}
