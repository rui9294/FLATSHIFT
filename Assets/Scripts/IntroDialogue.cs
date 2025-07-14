using UnityEngine;
using TMPro;
using System.Collections;

public class IntroDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private PlayerDotMove0D playerMovementScript;
    [SerializeField] private GameObject waitMark;

    [TextArea(2, 5)]
    public string[] dialogueLines;

    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float waitAfterFadeIn = 1.5f;
    [SerializeField] private float waitMarkFloatSpeed = 1f;
    [SerializeField] private float waitMarkFloatHeight = 10f;

    private int currentLine = 0;
    private Vector3 waitMarkOriginalPos;

    public void BeginDialogue()
    {
        playerMovementScript.enabled = false;
        dialoguePanel.SetActive(true);
        waitMarkOriginalPos = waitMark.transform.localPosition;
        waitMark.SetActive(false);
        StartCoroutine(ShowDialogue());
    }

    private IEnumerator ShowDialogue()
    {
        while (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];

            Color c = dialogueText.color;
            c.a = 0f;
            dialogueText.color = c;

            yield return StartCoroutine(FadeText(0f, 1f, fadeDuration));
            yield return new WaitForSeconds(waitAfterFadeIn);

            waitMark.SetActive(true);
            Coroutine floatMark = StartCoroutine(FloatWaitMark());

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            StopCoroutine(floatMark);
            waitMark.SetActive(false);
            waitMark.transform.localPosition = waitMarkOriginalPos;

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

        Color final = dialogueText.color;
        final.a = to;
        dialogueText.color = final;
    }

    private IEnumerator FloatWaitMark()
    {
        float timer = 0f;
        while (true)
        {
            float offsetY = Mathf.Sin(timer * waitMarkFloatSpeed) * waitMarkFloatHeight;
            waitMark.transform.localPosition = waitMarkOriginalPos + new Vector3(0f, offsetY, 0f);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
