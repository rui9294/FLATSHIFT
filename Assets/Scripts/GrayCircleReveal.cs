using UnityEngine;

public class GrayCircleReveal : MonoBehaviour
{
    public Transform player;          // �v���C���[�i���ہj
    public float revealDistance = 5f; // �v���C���[�������ׂ�����
    public float fadeSpeed = 1f;      // �t�F�[�h�C�����x

    private SpriteRenderer spriteRenderer;
    private float alpha = 0f;
    private bool revealed = false;
    private Vector3 startPos;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f); // ���S����
        startPos = player.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, startPos);

        if (!revealed && distance >= revealDistance)
        {
            revealed = true;
        }

        if (revealed && alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Clamp01(alpha));
        }
    }
}
