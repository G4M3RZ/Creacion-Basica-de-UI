using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static void MoveElement(Transform item, Vector2 local, Vector2 dir, float distance, float time, float delay, LeanTweenType anim, bool backwards)
    {
        float from = !backwards ? distance : 0;
        float to = !backwards ? 0 : distance;

        item.localPosition = local + (dir * from);

        LTDescr move = LeanTween.value(item.gameObject, from, to, time);
        move.setOnUpdate((float v) => item.localPosition = local + (dir * v));
        move.setDelay(delay);
        move.setEase(anim);
    }
    public static void MoveElements(List<Transform> items, List<Vector2> local, float distance, float time, float delay, LeanTweenType anim, bool backwards)
    {
        float from = backwards ? distance : 0;
        float to = backwards ? 0 : distance;

        for (int i = 0; i < items.Count; i++)
        {
            int id = i;

            LTDescr move = LeanTween.value(items[id].gameObject, from, to, time);
            move.setOnUpdate((float v) => items[id].localPosition = local[id] * v);
            move.setDelay(id * delay);
            move.setEase(anim);
        }
    }  
}