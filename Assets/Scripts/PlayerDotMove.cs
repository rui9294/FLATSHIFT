using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerDotMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask allowedLayers;

    private Rigidbody rb;
    private Vector3 lastMoveDir = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(h, v, 0f).normalized;
        if (input == Vector3.zero)
        {
            lastMoveDir = Vector3.zero;
            return;
        }

        // 移動予定位置
        Vector3 move = input * moveSpeed * Time.fixedDeltaTime;
        Vector3 nextPos = rb.position + move;
        nextPos.z = 0f;

        // 線との接触確認
        bool onLine = Physics.OverlapSphere(nextPos, 0.15f, allowedLayers).Length > 0;

        if (onLine)
        {
            lastMoveDir = input;

            // スナップ処理：進行方向に応じて吸着
            if (Mathf.Abs(input.x) > 0 && Mathf.Abs(input.y) == 0)
            {
                // 横移動：Yを吸着
                nextPos.y = Mathf.Round(rb.position.y * 10f) / 10f;
            }
            else if (Mathf.Abs(input.y) > 0 && Mathf.Abs(input.x) == 0)
            {
                // 縦移動：Xを吸着
                nextPos.x = Mathf.Round(rb.position.x * 10f) / 10f;
            }

            rb.MovePosition(nextPos);
        }
        else
        {
            Debug.LogWarning("【線外移動禁止】線の上にいないので停止");
        }
    }
}
