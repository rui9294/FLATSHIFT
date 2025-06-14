using UnityEngine;

public class TargetRevealOnMove : MonoBehaviour
{
    public Transform player;         // ����
    public GameObject targetCircle;  // �D�F�́�
    public float revealDistance = 5f;

    private Vector3 startPos;
    private bool revealed = false;

    void Start()
    {
        startPos = player.position;
        targetCircle.SetActive(false); // �ŏ��͔�\��
    }

    void Update()
    {
        if (!revealed && Vector3.Distance(player.position, startPos) > revealDistance)
        {
            targetCircle.SetActive(true);
            revealed = true;
        }
    }
}
