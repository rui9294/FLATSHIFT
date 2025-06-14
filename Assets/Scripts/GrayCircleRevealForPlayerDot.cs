using UnityEngine;

public class GrayCircleRevealForPlayerDot : MonoBehaviour
{
    public Transform player;
    public float revealDistance = 5f;    // プレイヤーが何メートル動いたら表示されるか
    public float fadeSpeed = 1f;

    private SpriteRenderer spriteRenderer;
    private float alpha = 1f;
    private bool revealed = false;
    private Vector3 initialPlayerPos;

    void Start()
    {
        gameObject.SetActive(true);
        spriteRenderer = GetComponent<SpriteRenderer>();

     
        spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f, alpha);

        initialPlayerPos = player.position; gameObject.SetActive(true); // ← 無理やりアクティブに！
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f, 1f); 
        initialPlayerPos = player.position;
    }

    void Update()
    {
        float movedDistance = Vector3.Distance(player.position, initialPlayerPos);

        if (!revealed && movedDistance > revealDistance)
        {
            revealed = true;
            Debug.Log("GrayCircle フェードイン開始！");
        }

        if (revealed && alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            float clampedAlpha = Mathf.Clamp01(alpha);
            spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f, clampedAlpha);

            if (clampedAlpha >= 1f)
            {
                enabled = false; // 完全に表示されたら処理終了
            }
        }
    }
}
