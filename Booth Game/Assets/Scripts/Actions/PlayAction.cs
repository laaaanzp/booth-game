using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAction : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] overlays;
    [SerializeField] private float loadDelay = 1f;
    [SerializeField] private TMP_InputField nameInput;


    public void Play()
    {
        if (string.IsNullOrWhiteSpace(nameInput.text) || nameInput.text.Length < 4 || nameInput.text.Length > 16)
        {
            MessageBoxControl.Open("Error", "The name must be 4 to 16 characters long.", MessageBoxButtons.OK);
            return;
        }

        BackgroundNumber[] backgroundNumbers = FindObjectsOfType<BackgroundNumber>();

        foreach (CanvasGroup overlay in overlays)
        {
            overlay.interactable = false;
            overlay.alpha = 0f;
        }

        foreach (BackgroundNumber backgroundNumber in backgroundNumbers)
        {
            backgroundNumber.Vanish(loadDelay);
        }
        Database.name = nameInput.text;
        StartCoroutine(nameof(LoadLevel), loadDelay);
    }

    private IEnumerator LoadLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1); // 1 = Level
    }
}
