using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float time;
    [SerializeField] private LeanTweenType start, end;

    private void Awake() => transform.localScale = Vector3.zero;
    private void Start() => LeanTween.scale(this.gameObject, Vector3.one, time).setEase(start);
    public void CloseButton() => LeanTween.scale(gameObject, Vector3.zero, time).setEase(end).setDestroyOnComplete(true);
}