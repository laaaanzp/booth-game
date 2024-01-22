using System;
using UnityEngine;

public class MessageBoxControl : MonoBehaviour
{
    [SerializeField] private GameObject messageBoxPrefab;

    private static MessageBoxControl instance;

    void Start()
    {
        instance = this;
    }

    public static void Open(string title, string message, MessageBoxButtons buttons, Action positiveAction = null, Action negativeAction = null)
    {
        GameObject messageBoxObj = Instantiate(instance.messageBoxPrefab, instance.transform);
        MessageBox messageBox = messageBoxObj.GetComponent<MessageBox>();

        if (buttons == MessageBoxButtons.OK)
        {
            messageBox.Open(title, message, positiveAction);
        }
        else if (buttons == MessageBoxButtons.YES_NO)
        {
            messageBox.Open(title, message, positiveAction, negativeAction);
        }
    }
}

public enum MessageBoxButtons
{
    OK, YES_NO
}
