using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailPreview : MonoBehaviour
{
    private static EmailPreview instance;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Selection selection;
    [SerializeField] private TextMeshProUGUI subjectText;
    [SerializeField] private TextMeshProUGUI fromText;
    [SerializeField] private TextMeshProUGUI possibleKeysText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private NumericUpDown numericUpDown;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private RectTransform rect;

    [SerializeField] private GameObject shiftObj;
    [SerializeField] private GameObject keyObj;

    private Email currentEmail;

    void Awake()
    {
        instance = this;
    }

    public static void Close()
    {
        instance.canvasGroup.alpha = 0f;
    }

    public void UpdateDisplay()
    {
        if (currentEmail == null) return;

        ShowInfo();
        ShowDefault();
    }

    public static void Open(Email email)
    {
        instance.currentEmail = email;
        instance.canvasGroup.alpha = 1f;
        instance.UpdateDisplay();
    }    

    private void ShowInfo()
    {
        subjectText.text = currentEmail.subject;
        fromText.text = $"From: {currentEmail.username} <{currentEmail.email}>";
    }

    private void ShowDefault()
    {
        messageText.text = currentEmail.message.Replace("{name}", Database.name);

        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
    }
}
