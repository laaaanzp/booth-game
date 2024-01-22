using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float duration = 2f;

    void Awake()
    {
        TransitionIn();
    }

    void TransitionIn()
    {
        LeanTween.alpha(image.rectTransform, 0f, duration).setEaseLinear().setIgnoreTimeScale(true).setOnComplete(() =>
        {
            image.raycastTarget = false;
        });
    }


    public void TransitionOut()
    {
        image.raycastTarget = true;
        LeanTween.alpha(image.rectTransform, 0f, duration).setEaseLinear().setIgnoreTimeScale(true);
    }
}
