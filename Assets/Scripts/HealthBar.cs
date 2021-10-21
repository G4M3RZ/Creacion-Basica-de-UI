using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Image topBar, lowBar;

    public void Update()
    {
        lowBar.fillAmount = Mathf.Lerp(lowBar.fillAmount, topBar.fillAmount, Time.deltaTime * speed);
    }
    public void Hit(int amount) => topBar.fillAmount -= amount / 100f;
}