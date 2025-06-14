using UnityEngine;

public class TargetCircleReveal3D : MonoBehaviour
{
    public Transform targetTransform;
    public float moveSpeed = 1f;
    public float fadeSpeed = 1f;
    public float revealDistance = 2f;

    private Transform playerTransform;
    private Vector3 initialPlayerPosition;
    private bool isRevealing = false;
    private SpriteRenderer sr;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        initialPlayerPosition = playerTransform.position;
        sr = GetComponent<SpriteRenderer>();
        var c = sr.color;
        c.a = 0f;
        sr.color = c;
    }

    void Update()
    {
        float moved = Vector3.Distance(initialPlayerPosition, playerTransform.position);
        if (!isRevealing && moved > revealDistance)
        {
            isRevealing = true;
        }

        if (isRevealing)
        {
            // フェードイン
            Color c = sr.color;
            c.a = Mathf.MoveTowards(c.a, 1f, fadeSpeed * Time.deltaTime);
            sr.color = c;

            // 移動
            targetTransform.position = Vector3.MoveTowards(
                targetTransform.position,
                new Vector3(0, 1, 0), // 好きな表示位置
                moveSpeed * Time.deltaTime
            );
        }
    }
}
