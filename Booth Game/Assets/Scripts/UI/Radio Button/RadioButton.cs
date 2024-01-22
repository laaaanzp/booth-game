using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadioButton : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    [Header("Colors")]
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color selectedColor = Color.cyan;

    [Header("Events")]
    [SerializeField] private UnityEvent onSelect;
    [SerializeField] private UnityEvent onDeselect;

    [Header("DO NOT TOUCH")]
    [SerializeField] private Outline outline;
    [SerializeField] private TextMeshProUGUI text;

    [HideInInspector] public Email email;

    public static RadioButton selected;
    private static List<RadioButton> instances;


    void Awake()
    {
        instances = new List<RadioButton>();
    }

    void Start()
    {
        instances.Add(this);
    }

    public void Initialize(Email email)
    {
        this.email = email;
        text.text = email.subject;
        onSelect.AddListener(new UnityAction(() => { EmailPreview.Open(email); }));
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (selected == this) return;
        selected = this;
        SetSelected();
        onSelect?.Invoke();
        OnSelectedChanged();    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (selected == this) return;
        SetDefault();
    }

    void OnValidate()
    {
        SetDefault();
    }

    public void SetDefault()
    {
        outline.effectColor = defaultColor;
        text.color = defaultColor;
    }

    public void SetSelected()
    {
        outline.effectColor = selectedColor;
        text.color = selectedColor;
    }

    public void OnSelectedChanged()
    {
        foreach (RadioButton radioButton in instances)
        {
            if (radioButton == this) continue;

            radioButton.SetDefault();
        }
    }

    void OnDestroy()
    {
        if (selected == this) selected = null;
        instances.Remove(this);
    }
}
