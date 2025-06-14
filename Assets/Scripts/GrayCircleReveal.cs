using UnityEngine;

public class GrayCircleReveal : MonoBehaviour
{
    public Transform player;          // プレイヤー（黒丸）
    public float revealDistance = 5f; // プレイヤーが動くべき距離
    public float fadeSpeed = 1f;      // フェードイン速度

    private SpriteRenderer spriteRenderer;
    private float alpha = 0f;
    private bool revealed = false;
    private Vector3 startPos;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f); // 完全透明
        startPos = player.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, startPos);

        if (!revealed && distance >= revealDistance)
        {
            revealed = true;
        }

        if (revealed && alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Clamp01(alpha));
        }
    }
}
