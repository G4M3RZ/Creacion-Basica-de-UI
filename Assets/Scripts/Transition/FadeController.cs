using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    None = -1,
    test1 = 0,
    test2 = 1,
    Exit = 2
}
[System.Serializable] public struct Fade
{
    public CanvasGroup canvasGroup;
    [Range(0, 2)] public float time;
}
public class FadeController : MonoBehaviour
{
    [SerializeField] Fade fade;
    private SceneName sceneName = SceneName.None;

    private void Start()
    {
        int sceneType = (int)sceneName;

        int start = (sceneType >= 0) ? 0 : 1;
        int end = (sceneType >= 0) ? 1 : 0;

        fade.canvasGroup.alpha = start;

        LTDescr tween = LeanTween.alphaCanvas(fade.canvasGroup, end, fade.time);
        tween.setOnComplete(() => 
        {
            if (sceneType == (int)SceneName.Exit) Application.Quit();
            else if (sceneType < 0) Destroy(gameObject);
            else SceneManager.LoadScene(sceneType);
        });
    }
    public void SetSceneType(SceneName scene) => sceneName = scene;
}