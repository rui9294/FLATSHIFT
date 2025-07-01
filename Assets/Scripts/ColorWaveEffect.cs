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
        Debug.Log("破門スタート");  // ← ログ確認用！

        float timer = 0f;
        Vector3 initialScale = transform.localScale;

        while (timer < waveDuration)
        {
            float scale = Mathf.Lerp(1f, 5f, timer / waveDuration);
            transform.localScale = new Vector3(scale, scale, 1f);
            timer += Time.deltaTime;
            yield return null;
        }

        // 波紋を終了し、非表示に戻す
        transform.localScale = initialScale;
        gameObject.SetActive(false);
    }
}
