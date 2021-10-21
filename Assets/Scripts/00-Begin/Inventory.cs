using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float time;
    [SerializeField] private LeanTweenType curve;
    [SerializeField] private GameObject slider;

    public void Open()
    {
        LeanTween.moveLocalX(slider, 0, time).setEase(curve).setOnUpdate(Anim);
    }
    private void Anim(float v)
    {

    }
    public void Close() => LeanTween.moveLocalX(slider, -700, time).setEase(curve);
}