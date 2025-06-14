using UnityEngine;
using UnityEngine.UI;

public class FadeInCircle : MonoBehaviour
{
    public RectTransform targetCircle;
    public CanvasGroup canvasGroup;

    public float moveSpeed = 200f;
    public float fadeDuration = 1f;
    public Vector3 targetPosition;

    private bool shouldReveal = false;
    private float fadeTimer = 0f;

    void Start()
    {
        // 最初は透明＋画面外
        canvasGroup.alpha = 0f;
    }

    void Update()
    {
        if (shouldReveal)
        {
            // 位置をなめらかに移動
            targetCircle.anchoredPosition = Vector3.MoveTowards(
                targetCircle.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);

            // 徐々にフェードイン
            if (canvasGroup.alpha < 1f)
            {
                fadeTimer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Clamp01(fadeTimer / fadeDuration);
            }
        }
    }

    // 外部から呼び出す
    public void TriggerReveal()
    {
        shouldReveal = true;
    }
}
