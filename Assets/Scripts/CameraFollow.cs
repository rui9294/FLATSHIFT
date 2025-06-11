using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // �ǂ����������Ώہi���ہj
    public Vector3 offset = new Vector3(0f, 0f, -10f);  // �J�����̏���Z�ʒu
    public float smoothSpeed = 5f; // �J�����̒ǔ��X�s�[�h

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPosition;
    }
}
