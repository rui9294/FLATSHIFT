using UnityEngine;
using UnityEngine.SceneManagement;

public class GrayCircleSpringEffect : MonoBehaviour
{
    public string nextSceneName = "SecondScene";  // �� ������ύX�I
    public float startDelay = 1f;
    public float shrinkDuration = 0.2f;
    public float pauseDuration = 0.1f;
    public float expandDuration = 0.5f;
    public float maxScale = 30f;
    public AnimationCurve springCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);


    private bool triggered = false;
    private float timer = 0f;
    private Vector3 originalScale;
    private SpriteRenderer spriteRenderer;

    private enum State { Idle, StartDelay, Shrinking, Pause, Expanding, Done }
    private State state = State.Idle;

    void Start()
    {
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            state = State.StartDelay;
            timer = 0f;
            Debug.Log("�� �ڐG�I�k�ނ܂őҋ@��...");
        }
    }

    void Update()
    {
        if (!triggered) return;

        timer += Time.deltaTime;

        switch (state)
        {
            case State.StartDelay:
                if (timer >= startDelay)
                {
                    state = State.Shrinking;
                    timer = 0f;
                    Debug.Log("�� �k�݊J�n�I");
                }
                break;

            case State.Shrinking:
                float tShrink = Mathf.Clamp01(timer / shrinkDuration);
                float shrinkScale = Mathf.Lerp(originalScale.x, originalScale.x * 0.2f, tShrink);
                transform.localScale = new Vector3(shrinkScale, shrinkScale, 1f);

                if (tShrink >= 1f)
                {
                    state = State.Pause;
                    timer = 0f;
                    Debug.Log("�� �k�݊��� �� �^���I");
                }
                break;

            case State.Pause:
                if (timer >= pauseDuration)
                {
                    state = State.Expanding;
                    timer = 0f;
                    Debug.Log("�� �ς������I�I�i�g��j");
                }
                break;

            case State.Expanding:
                float tExpand = Mathf.Clamp01(timer / expandDuration);
                float easedT = springCurve != null ? springCurve.Evaluate(tExpand) : tExpand;

                float scale = Mathf.Lerp(originalScale.x * 0.2f, maxScale, easedT);
                transform.localScale = new Vector3(scale, scale, 1f);

                Color c = spriteRenderer.color;
                c.a = Mathf.Lerp(0.5f, 1f, easedT);
                spriteRenderer.color = c;

                if (tExpand >= 1f)
                {
                    state = State.Done;
                    Invoke("LoadNextScene", 0.2f);
                    Debug.Log("�� �V�[���J�ڏ������I");
                }
                break;
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);  // �� ������ "SecondScene" �ɐݒ肳��Ă�I
    }
}
