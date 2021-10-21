using System.Collections.Generic;
using UnityEngine;

public class UIGroupAnimation2 : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] float time;
    [SerializeField] private LeanTweenType animCurve;
    [SerializeField] private List<Transform> items;

    private List<Vector2> pos = new List<Vector2>();

    private void Awake()
    {
        for (int i = 0; i < items.Count; i++)
        {
            pos.Add(items[i].localPosition);
            items[i].localPosition = Vector2.zero;
        }
    }
    public void Animation()
    {
        //Set Position to 0
        for (int i = 0; i < items.Count; i++) items[i].localPosition = Vector2.zero;

        //Apply Animation
        for (int i = 0; i < items.Count; i++)
        {
            int id = i;

            LTDescr move = LeanTween.value(items[id].gameObject, 0, 1, time);
            move.setOnUpdate((float v) => items[id].localPosition = pos[id] * v);
            move.setEase(animCurve);
        }
    }
}