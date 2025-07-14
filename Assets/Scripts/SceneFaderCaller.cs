using UnityEngine;
using System.Collections;

public class SceneFaderCaller : MonoBehaviour
{
    [SerializeField] private IntroDialogue introDialogue;

    private void Start()
    {
        SceneFader fader = Object.FindFirstObjectByType<SceneFader>();
        if (fader != null)
        {
            StartCoroutine(FadeAndStartDialogue(fader));
        }
        else
        {
            Debug.LogWarning("SceneFader Ç™å©Ç¬Ç©ÇËÇ‹ÇπÇÒÇ≈ÇµÇΩÅB");
        }
    }

    private IEnumerator FadeAndStartDialogue(SceneFader fader)
    {
        yield return fader.FadeInFromWhiteCoroutine();
        introDialogue.BeginDialogue();
    }
}
