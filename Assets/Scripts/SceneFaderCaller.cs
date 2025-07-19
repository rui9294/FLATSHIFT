using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFaderCaller : MonoBehaviour
{
    [SerializeField] private IntroDialogue introDialogue;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "TitleScene") // タイトルシーンならスキップ
        {
            if (SceneFader.Instance != null)
            {
                StartCoroutine(FadeAndStartDialogue());
            }
        }
    }

    private IEnumerator FadeAndStartDialogue()
    {
        yield return SceneFader.Instance.FadeInFromWhiteCoroutine();
        if (introDialogue != null)
        {
            introDialogue.BeginDialogue();
        }
    }
}
