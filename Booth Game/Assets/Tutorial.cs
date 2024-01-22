using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    void Awake()
    {
        text.text = text.text.Replace("{name}", Database.name);
    }
}
