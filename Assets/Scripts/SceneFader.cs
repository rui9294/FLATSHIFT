using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance { get; private set; }

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1.5f;

    private bool hasFadedIn = false;

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
            // 最初は透明（フェードイン開始前）
            fadeImage.color = new Color(1, 1, 1, 0f);
        }
    }

    // タイトル以外で呼ばれることを想定
    public IEnumerator FadeInFromWhiteCoroutine()
    {
        if (fadeImage == null) yield break;

        float t = 0f;
        fadeImage.color = new Color(1, 1, 1, 1f); // 最初は真っ白

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        fadeImage.color = new Color(1, 1, 1, 0f);
        hasFadedIn = true;
    }

    private IEnumerator FadeOutToWhiteCoroutine()
    {
        if (fadeImage == null) yield break;

        float t = 0f;
        fadeImage.color = new Color(1, 1, 1, 0f); // 最初は透明

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        fadeImage.color = new Color(1, 1, 1, 1f); // 最後は真っ白
    }

    // シーン切り替え用（例：FadeToScene("GameScene")）
    public void FadeToScene(string GameScene)
    {
        StartCoroutine(FadeOutAndLoadScene(GameScene));
    }

    private IEnumerator FadeOutAndLoadScene(string GameScene)
    {
        yield return FadeOutToWhiteCoroutine();
        SceneManager.LoadScene(GameScene);
    }
}
