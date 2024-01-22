using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private Transform rowsTransform;

    private float firstPos;

    void Awake()
    {
        firstPos = Mathf.Abs(gameObject.transform.localPosition.y);
        Invoke(nameof(Loop), 0f);
    }

    private void Loop()
    {
        LeanTween.moveLocalY(gameObject, firstPos + 3f, 5f).setOnComplete(() =>
        {
            Vector3 localPosition = gameObject.transform.localPosition;
            localPosition.y = -firstPos;
            gameObject.transform.localPosition = localPosition;

            rowsTransform.GetChild(0).SetAsLastSibling();
        }).setEaseLinear().setRepeat(-1).setOnCompleteOnRepeat(true); 
    }

    void Update()
    {
    }
}
