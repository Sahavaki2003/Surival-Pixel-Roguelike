
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer fillRenderer;

    private float maxHp;
    private Vector3 originalScale;
    private Vector3 originalPosition;
    private void OnEnable()
    {
        originalScale = fillRenderer.transform.localScale;
        originalPosition = fillRenderer.transform.localPosition;
    }

    public void UpdateHealthBar(float Hp, float initialHp)
    {
        if (initialHp <= 0f) return;

        float percent = Mathf.Clamp01(Hp / initialHp);

        Vector3 scale = originalScale;
        scale.x = originalScale.x * percent;
        fillRenderer.transform.localScale = scale;

        Vector3 position = originalPosition;
        position.x = originalPosition.x - (originalScale.x * (1f - percent) / 2f);

        fillRenderer.transform.localPosition = position;
    }
}
