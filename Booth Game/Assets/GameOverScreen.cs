using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loadingText;
    [SerializeField] RectTransform rect;


    void Awake()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        StartCoroutine(nameof(Loading));
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.5f);
        loadingText.text = "39% complete";

        yield return new WaitForSeconds(0.1f);
        loadingText.text = "42% complete";

        yield return new WaitForSeconds(1f);
        loadingText.text = "50% complete";

        yield return new WaitForSeconds(0.4f);
        loadingText.text = "55% complete";

        yield return new WaitForSeconds(1f);
        loadingText.text = "80% complete";

        yield return new WaitForSeconds(0.25f);
        loadingText.text = "95% complete";

        yield return new WaitForSeconds(0.75f);
        loadingText.text = "100% complete";

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
