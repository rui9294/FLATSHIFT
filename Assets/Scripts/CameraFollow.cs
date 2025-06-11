using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // 追いかけたい対象（黒丸）
    public Vector3 offset = new Vector3(0f, 0f, -10f);  // カメラの初期Z位置
    public float smoothSpeed = 5f; // カメラの追尾スピード

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPosition;
    }
}
