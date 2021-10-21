using UnityEngine;

public class FadeButtons : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float time, delay;
    [SerializeField] private LeanTweenType curve;
    [SerializeField] private CanvasGroup[] alpha;

    private void Start()
    {
        //LTSeq seq = LeanTween.sequence();

        for (int i = 0; i < alpha.Length; i++)
        {
            int id = i;

            //Set values to 0
            alpha[id].alpha = 0;

            //Animation
            //seq.append(LeanTween.alphaCanvas(alpha[id], 1, 0.5f).setEase(curve));
            //seq.append(0.5f);
            //Debug.Log(id * delay);
            LeanTween.alphaCanvas(alpha[id], 1, time).setEase(curve).setDelay(id * delay);
        }
    }
}