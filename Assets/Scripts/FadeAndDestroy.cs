using UnityEngine;

public class FadeAndDestroy : MonoBehaviour
{
    public float lifetime = 0.5f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float timer = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / lifetime;
        float alpha = Mathf.Lerp(originalColor.a, 0f, t);

        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
