using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StartButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform buttonRect;
    public TextMeshProUGUI startText;
    public float hoverScale = 1.3f;
    public float speed = 5f;

    private Vector3 originalScale;
    private bool isHovering = false;

    void Start()
    {
        originalScale = buttonRect.localScale;
        startText.alpha = 0f; // 最初は見えない
    }

    void Update()
    {
        // 拡大・縮小のアニメーション
        Vector3 targetScale = isHovering ? originalScale * hoverScale : originalScale;
        buttonRect.localScale = Vector3.Lerp(buttonRect.localScale, targetScale, Time.deltaTime * speed);

        // テキストのフェードイン・アウト
        float targetAlpha = isHovering ? 1f : 0f;
        startText.alpha = Mathf.Lerp(startText.alpha, targetAlpha, Time.deltaTime * speed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
