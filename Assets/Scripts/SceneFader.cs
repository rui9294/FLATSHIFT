using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance { get; private set; }

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (fadeImage != null)
        {
            fadeImage.color = new Color(1, 1, 1, 0f);
        }
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator FadeInFromWhiteCoroutine()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        fadeImage.color = new Color(1, 1, 1, 0f);
    }

    // ŒÝŠ·«ˆÛŽ‚Ì‚½‚ß‚ÉŽc‚µ‚Ä‚¨‚­
    public void FadeFromWhite()
    {
        StartCoroutine(FadeInFromWhiteCoroutine());
    }
}
