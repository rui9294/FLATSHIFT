using UnityEngine;
using System.Collections;

public class ColorWaveEffect : MonoBehaviour
{
    public float waveDuration = 2f;

    public void StartWave()
    {
        StartCoroutine(WaveEffect());
    }

    private IEnumerator WaveEffect()
    {
        Debug.Log("�j��X�^�[�g");  // �� ���O�m�F�p�I

        float timer = 0f;
        Vector3 initialScale = transform.localScale;

        while (timer < waveDuration)
        {
            float scale = Mathf.Lerp(1f, 5f, timer / waveDuration);
            transform.localScale = new Vector3(scale, scale, 1f);
            timer += Time.deltaTime;
            yield return null;
        }

        // �g����I�����A��\���ɖ߂�
        transform.localScale = initialScale;
        gameObject.SetActive(false);
    }
}
