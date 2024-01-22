using UnityEngine;

public class PauseOnActive : MonoBehaviour
{
    private float defaultTimeScale;


    private void OnEnable()
    {
        defaultTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = defaultTimeScale;
    }
}
