using UnityEngine;

public class ShadowFollower : MonoBehaviour
{
    public Transform target;        // �v���C���[�i���ہj�������ɃA�T�C��
    public float followSpeed = 5f;  // �x��Ēǂ����X�s�[�h
    public float offset = 0.1f;     // �ق�̏��������x���

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position;
            // �x��Ēǂ�������i�Ȃ߂炩�Ɂj
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, offset / followSpeed);
        }
    }
}
