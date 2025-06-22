using UnityEngine;

public class MelodyDotState : MonoBehaviour
{
    public float whiteTime = 0.2f;  // �ʂ��i���j����
    public float blackTime = 0.8f;  // �ʂ�Ȃ��i���j����
    public Color activeColor = Color.white;
    public Color inactiveColor = new Color(0f, 0.12f, 0.25f);

    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private bool isActive = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        StartCoroutine(SwitchStateRoutine());
    }

    private System.Collections.IEnumerator SwitchStateRoutine()
    {
        while (true)
        {
            // ����ԁi�ʂ��j
            isActive = true;
            spriteRenderer.color = activeColor;
            if (col != null)
                col.isTrigger = true;

            yield return new WaitForSeconds(whiteTime);

            // ����ԁi�ʂ�Ȃ��j
            isActive = false;
            spriteRenderer.color = inactiveColor;
            if (col != null)
                col.isTrigger = false;

            yield return new WaitForSeconds(blackTime);
        }
    }

    public bool IsPassable()
    {
        return isActive;
    }
}
