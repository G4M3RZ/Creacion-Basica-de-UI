using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    [SerializeField] private SceneName newScene;

    public void ChangeSceneButton() => Instantiate(fade, transform).GetComponent<FadeController>().SetSceneType(newScene);
}