using UnityEngine;
using TMPro;

public class FadeOutOnMove : MonoBehaviour
{
    public TMP_Text textToFade;
    public Transform player;
    public float fadeDuration = 1f;
    public float movementThreshold = 0.1f;
    public float delayBeforeFade = 1f; // Å© í«â¡ÅFë“ã@éûä‘

    private bool hasMoved = false;
    private Vector3 startPos;

    void Start()
    {
        startPos = player.position;
        SetAlpha(1f);
    }

    void Update()
    {
        if (!hasMoved && Vector3.Distance(player.position, startPos) > movementThreshold)
        {
            hasMoved = true;
            StartCoroutine(WaitThenFadeOut());
        }
    }

    System.Collections.IEnumerator WaitThenFadeOut()
    {
        yield return new WaitForSeconds(delayBeforeFade); // Å© Ç±Ç±Ç≈1ïbë“Ç¬
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            SetAlpha(alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        SetAlpha(0f);
    }

    void SetAlpha(float alpha)
    {
        Color c = textToFade.color;
        c.a = alpha;
        textToFade.color = c;
    }
}
