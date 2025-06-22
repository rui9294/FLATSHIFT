using UnityEngine;

public class MelodyDotState : MonoBehaviour
{
    public float switchInterval = 1.0f;      // ���̔��̐؂�ւ��Ԋu�i�b�j
    public Color activeColor = Color.white; // �ʂ�鎞�̐F�i���j
    public Color inactiveColor = new Color(0f, 0.12f, 0.25f); // �ʂ�Ȃ��Ƃ��i�[���j

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

    // �O�������Ԃ��擾���邽�߂̌��J���\�b�h
    public bool IsPassable()
    {
        return isActive;
    }
}
