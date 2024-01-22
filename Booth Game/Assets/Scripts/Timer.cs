using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float delay = 2f;

    private bool isStarted = false;
    private float totalTime = 0f;

    void Awake()
    {
        InvokeRepeating(nameof(UpdateTimeDisplay), 0f, 0.5f);
        Invoke(nameof(StartTimer), delay);
    }

    void StartTimer()
    {
        isStarted = true;
    }

    void UpdateTimeDisplay()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);

        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update()
    {
        if (!isStarted) return;

        totalTime += Time.deltaTime;
    }
}
