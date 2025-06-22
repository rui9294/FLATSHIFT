using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // 追いかけたい対象（黒丸）
    public Vector3 offset = new Vector3(0f, 0f, -10f);  // カメラのオフセット
    public float smoothSpeed = 5f; // カメラの追尾スピード

    [HideInInspector]
    public bool isFrozen = false;  // 外部から追従を一時停止させるフラグ

    void LateUpdate()
    {
        if (target == null || isFrozen)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPosition;
    }
}
