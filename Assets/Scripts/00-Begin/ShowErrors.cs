using System.Collections;
using UnityEngine;

public class ShowErrors : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private float startDelay, secondDelay;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private Transform parent;
    [Space]
    [SerializeField] private GameObject errorMessage;
    [SerializeField] private GameObject succesfullMessage;

    private void Start() => StartCoroutine(ErrorMessages());

    private IEnumerator ErrorMessages()
    {
        yield return new WaitForSeconds(startDelay);

        float width = canvas.sizeDelta.x / 2;
        float heigt = canvas.sizeDelta.y / 2;

        //Start Message
        for (int i = 0; i < 2; i++)
        {
            Instance(errorMessage, Vector2.zero);
            yield return new WaitForSeconds(secondDelay);
        }

        //Random Messages
        for (int i = 0; i < 30; i++)
        {
            Instance(errorMessage, RandomVector2(-width, width, -heigt, heigt));
            yield return new WaitForSeconds(0.1f);
        }

        //Trail Messages
        Vector2 dir = Vector2.down + Vector2.left;

        for (int i = 0; i < 3; i++)
        {
            Vector2 randomPos = RandomVector2(-width / 2, width, 0, heigt);

            for (int e = 0; e < 8; e++)
            {
                Instance(errorMessage, randomPos);
                yield return new WaitForSeconds(0.1f);
                randomPos += dir * 50;
            }
        }

        //Final Message
        Instance(succesfullMessage, Vector2.zero);
    }
    private Vector2 RandomVector2(float minX, float maxX, float minY, float maxY)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }
    private void Instance(GameObject prefab, Vector2 area)
    {
        RectTransform item = Instantiate(prefab, parent).GetComponent<RectTransform>();

        if (area == Vector2.zero) return;

        Vector2 size = item.sizeDelta / 2;

        Vector2 dir;
        dir.x = area.x > 0 ? -size.x : size.x;
        dir.y = area.y > 0 ? -size.y : size.y;

        item.localPosition = area + dir;
    }
}