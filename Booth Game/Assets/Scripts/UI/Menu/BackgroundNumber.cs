using System.Collections;
using TMPro;
using UnityEngine;

public class BackgroundNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private int value;
    private Coroutine coroutine;


    void Awake()
    {
        value = Random.Range(0, 2);
        text.text = value.ToString();

        coroutine = StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        while (true)
        {
            float randomSleep = Random.Range(0f, 5f);
            yield return new WaitForSeconds(randomSleep);

            int randomNumber = Random.Range(0, 20);
            if (randomNumber != 1) continue;

            value = value == 0 ? 1 : 0;
            text.text = value.ToString();
        }
    }
    void OnValidate()
    {
        value = Random.Range(0, 2);
        text.text = value.ToString();
    }

    public void Vanish(float maxDelay)
    {
        StopCoroutine(coroutine);
        StartCoroutine(nameof(_Vanish), maxDelay);
    }

    private IEnumerator _Vanish(float maxDelay)
    {
        maxDelay = Random.Range(0f, maxDelay);
        yield return new WaitForSeconds(maxDelay);
        text.color = new Color(1f, 1f, 1f, 0f); // Transparent
    }
}
