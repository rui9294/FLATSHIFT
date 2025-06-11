using UnityEngine;

public class ShadowFollower : MonoBehaviour
{
    public Transform target;        // プレイヤー（黒丸）をここにアサイン
    public float followSpeed = 5f;  // 遅れて追いつくスピード
    public float offset = 0.1f;     // ほんの少しだけ遅れる

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position;
            // 遅れて追いかける（なめらかに）
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, offset / followSpeed);
        }
    }
}
