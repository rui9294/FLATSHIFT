using UnityEngine;

public class PlayerDotMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public LayerMask cellLayer;

    private Vector3 moveDir;
    private Vector3 targetPos;
    private bool isMoving = false;

    private void Start()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            moveDir = new Vector3(h, v, 0).normalized;

            if (moveDir != Vector3.zero)
            {
                Vector3 nextPos = transform.position + moveDir;
                nextPos = new Vector3(Mathf.Round(nextPos.x), Mathf.Round(nextPos.y), 0);

                if (IsCellPassable(nextPos, moveDir))
                {
                    targetPos = nextPos;
                    isMoving = true;
                }
                else
                {
                    Debug.Log("❌ 通れない方向だよ");
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                transform.position = targetPos;
                isMoving = false;
            }
        }
    }

    private bool IsCellPassable(Vector3 gridPos, Vector3 dir)
    {
        // ① PathLine確認（変わらず）
        Collider[] hits = Physics.OverlapSphere(gridPos, 0.05f, cellLayer);
        bool hasPath = false;

        foreach (var hit in hits)
        {
            PassableCell cell = hit.GetComponent<PassableCell>();
            if (cell != null)
            {
                if (cell.allowedAxis == PassableCell.Axis.Both) hasPath = true;
                if (cell.allowedAxis == PassableCell.Axis.Horizontal && Mathf.Abs(dir.x) > 0) hasPath = true;
                if (cell.allowedAxis == PassableCell.Axis.Vertical && Mathf.Abs(dir.y) > 0) hasPath = true;
            }
        }

        if (!hasPath)
        {
            Debug.Log("🛣 PathLineがない！");
            return false;
        }

        // ② 同じグリッドにいる MelodyDot を判定（距離ベースで近接チェック）
        GameObject[] dots = GameObject.FindGameObjectsWithTag("MelodyDot");
        foreach (var dot in dots)
        {
            if (Vector3.Distance(dot.transform.position, gridPos) < 0.1f)
            {
                MelodyDotState state = dot.GetComponent<MelodyDotState>();
                if (state != null && !state.IsPassable())
                {
                    Debug.Log("🚫 MelodyDotと同じマスにあり、通れない！");
                    return false;
                }
            }
        }

        return true;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(targetPos, Vector3.one * 0.9f);
    }
}
