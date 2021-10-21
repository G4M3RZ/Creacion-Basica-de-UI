using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float time;
    [SerializeField] private LeanTweenType curve;

    private void Start() => LeanTween.rotateAroundLocal(gameObject, Vector3.up, 360, time).setEase(curve).setLoopClamp();

    //private void Start() => LeanTween.value(gameObject, 0, 360, time).setOnUpdate(Rot).setEase(curve).setLoopClamp();
    //private void Rot(float v) => transform.localEulerAngles = new Vector3(0, v, 0);
}