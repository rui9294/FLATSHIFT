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
                nextPos = new Vector3(Mathf.Round(nextPos.x), Mathf.Round(nextPos.y), 0); // グリッド整列

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

    private bool IsCellPassable(Vector3 checkPos, Vector3 dir)
    {
        Collider[] hits = Physics.OverlapSphere(checkPos, 0.05f, cellLayer);
        foreach (var hit in hits)
        {
            PassableCell cell = hit.GetComponent<PassableCell>();
            if (cell != null)
            {
                if (cell.allowedAxis == PassableCell.Axis.Both) return true;
                if (cell.allowedAxis == PassableCell.Axis.Horizontal && Mathf.Abs(dir.x) > 0) return true;
                if (cell.allowedAxis == PassableCell.Axis.Vertical && Mathf.Abs(dir.y) > 0) return true;
            }
        }
        return false;
    }
}
