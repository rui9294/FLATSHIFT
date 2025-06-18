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

            // �ŏ��ɓ�����
            Color c = dialogueText.color;
            c.a = 0f;
            dialogueText.color = c;

            // �t�F�[�h�C��
            yield return StartCoroutine(FadeText(0f, 1f, fadeDuration));

            // �ҋ@
            yield return new WaitForSeconds(waitAfterFadeIn);

            // �N���b�N�҂�
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            // �t�F�[�h�A�E�g
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
        // �ŏI�l�␳
        Color final = dialogueText.color;
        final.a = to;
        dialogueText.color = final;
    }
}
