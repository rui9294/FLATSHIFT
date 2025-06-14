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
        // �ŏ��͓����{��ʊO
        canvasGroup.alpha = 0f;
    }

    void Update()
    {
        if (shouldReveal)
        {
            // �ʒu���Ȃ߂炩�Ɉړ�
            targetCircle.anchoredPosition = Vector3.MoveTowards(
                targetCircle.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);

            // ���X�Ƀt�F�[�h�C��
            if (canvasGroup.alpha < 1f)
            {
                fadeTimer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Clamp01(fadeTimer / fadeDuration);
            }
        }
    }

    // �O������Ăяo��
    public void TriggerReveal()
    {
        shouldReveal = true;
    }
}
