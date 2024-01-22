using Kino;
using System.Collections;
using UnityEngine;

public class GlitchEffectControl : MonoBehaviour
{
    [SerializeField] private AnalogGlitch analogGlitch;

    [Header("Delay")]
    [SerializeField] private float minDelay = 4f;
    [SerializeField] private float maxDelay = 7f;

    [Header("Color Drift Level")]
    [Range(0f, 1f)] [SerializeField] private float minLevel = 0f;
    [Range(0f, 1f)] [SerializeField] private float maxLevel = 1f;

    void Awake()
    {
        StartCoroutine(nameof(Loop));
    }

    IEnumerator Loop()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            float level = Random.Range(minLevel, maxLevel);
            analogGlitch.colorDrift = level;

            yield return new WaitForSeconds(0.05f);
            analogGlitch.colorDrift = 0f;
        }    
    }
}
