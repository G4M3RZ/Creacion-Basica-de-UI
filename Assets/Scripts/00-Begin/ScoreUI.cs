using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float time, delay;
    [SerializeField] private LeanTweenType curve;
    [SerializeField] private Transform[] stars;
    [SerializeField] private Transform text;

    public void PlayAnimation()
    {
        //Text
        text.localPosition = Vector2.down * 300;
        LeanTween.moveLocalY(text.gameObject, 0, time).setEase(curve);

        //Stars
        for (int i = 0; i < stars.Length; i++)
        {
            int id = i;
            float delayTime = id * delay;

            GameObject item = stars[id].gameObject;

            Image color = item.GetComponent<Image>();
            CanvasGroup alpha = item.GetComponent<CanvasGroup>();
            
            stars[id].localScale = Vector3.zero;
            alpha.alpha = 0;

            LTSeq seq = LeanTween.sequence();
            seq.append(delayTime);
            seq.append(() =>
            {
                LeanTween.alphaCanvas(alpha, 1, time);
                LeanTween.scale(item, Vector3.one, time).setEase(curve);
            });
            seq.append(() =>
            {
                LeanTween.scale(item, new Vector3(1.2f, 1.2f, 1.2f), 0.2f).setLoopOnce();
            });
        }
    }
}