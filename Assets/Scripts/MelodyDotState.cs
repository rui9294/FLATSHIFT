using UnityEngine;

public class MelodyDotState : MonoBehaviour
{
    [SerializeField] private float bpm = 50f; // 明滅テンポ
    [SerializeField] private float whiteRatio = 0.25f; // 白：黒の比率（1拍中）

    [SerializeField] private Color activeColor = Color.white;
    [SerializeField] private Color inactiveColor = new Color(0f, 0.12f, 0.25f);

    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private bool isActive = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        StartCoroutine(SwitchStateRoutine());
    }

    private System.Collections.IEnumerator SwitchStateRoutine()
    {
        float interval = 60f / bpm;
        float whiteTime = interval * whiteRatio;
        float blackTime = interval * (1f - whiteRatio);

        while (true)
        {
            // 白（通過可能）
            isActive = true;
            spriteRenderer.color = activeColor;
            if (col != null) col.isTrigger = true;
            yield return new WaitForSeconds(whiteTime);

            // 黒（通過不可）
            isActive = false;
            spriteRenderer.color = inactiveColor;
            if (col != null) col.isTrigger = false;
            yield return new WaitForSeconds(blackTime);
        }
    }

    public bool IsPassable()
    {
        return isActive;
    }
}
