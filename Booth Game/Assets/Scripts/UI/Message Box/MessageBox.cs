using System;
using TMPro;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI messsageText;

    [Header("Buttons")]
    [SerializeField] private GameObject okButton;
    [SerializeField] private GameObject yesButton;
    [SerializeField] private GameObject noButton;

    private Action positiveAction;
    private Action negativeAction;


    public void Open(string title, string message, Action okAction)
    {
        okButton.SetActive(true);
        noButton.SetActive(false);
        yesButton.SetActive(false);

        SetLabels(title, message);

        positiveAction = okAction;
    }
 
    public void Open(string title, string message, Action yesAction, Action noAction)
    {
        okButton.SetActive(false);
        noButton.SetActive(true);
        yesButton.SetActive(true);

        SetLabels(title, message);

        positiveAction = yesAction;
        negativeAction = noAction;
    }

    private void SetLabels(string title, string message)
    {
        titleText.text = title;
        messsageText.text = message;
    }

    public void PositionAction()
    {
        positiveAction?.Invoke();
        Destroy(gameObject);
    }

    public void NegativeAction()
    {
        negativeAction?.Invoke();
        Destroy(gameObject);
    }
}
