using UnityEngine;

public class MelodyDotState : MonoBehaviour
{
    public float switchInterval = 1.0f;      // 黒⇔白の切り替え間隔（秒）
    public Color activeColor = Color.white; // 通れる時の色（白）
    public Color inactiveColor = new Color(0f, 0.12f, 0.25f); // 通れないとき（深い青）

    private SpriteRenderer spriteRenderer;
    private bool isActive = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SwitchStateRoutine());
    }

    private System.Collections.IEnumerator SwitchStateRoutine()
    {
        while (true)
        {
            isActive = !isActive;
            spriteRenderer.color = isActive ? activeColor : inactiveColor;
            yield return new WaitForSeconds(switchInterval);
        }
    }

    // 外部から状態を取得するための公開メソッド
    public bool IsPassable()
    {
        return isActive;
    }
}
