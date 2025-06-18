using UnityEngine;
using TMPro;
using System.Collections;

public class IntroDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private PlayerDotMove playerMovementScript;

    [TextArea(2, 5)]
    public string[] dialogueLines;

    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float waitAfterFadeIn = 1.5f;

    private int currentLine = 0;

    void Start()
    {
        playerMovementScript.enabled = false;
        dialoguePanel.SetActive(true);
        StartCoroutine(ShowDialogue());
    }

    private IEnumerator ShowDialogue()
    {
        while (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];

            // 最初に透明に
            Color c = dialogueText.color;
            c.a = 0f;
            dialogueText.color = c;

            // フェードイン
            yield return StartCoroutine(FadeText(0f, 1f, fadeDuration));

            // 待機
            yield return new WaitForSeconds(waitAfterFadeIn);

            // クリック待ち
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            // フェードアウト
            yield return StartCoroutine(FadeText(1f, 0f, fadeDuration));

            currentLine++;
        }

        dialoguePanel.SetActive(false);
        playerMovementScript.enabled = true;
    }

    private IEnumerator FadeText(float from, float to, float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            float alpha = Mathf.Lerp(from, to, timer / duration);
            Color c = dialogueText.color;
            c.a = alpha;
            dialogueText.color = c;

            timer += Time.deltaTime;
            yield return null;
        }
        // 最終値補正
        Color final = dialogueText.color;
        final.a = to;
        dialogueText.color = final;
    }
}
