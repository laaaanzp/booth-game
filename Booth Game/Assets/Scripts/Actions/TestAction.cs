using UnityEngine;

public class TestAction : MonoBehaviour
{
    public Email email;

    public void Test()
    {
        EmailPreview.Open(email);
    }
}
