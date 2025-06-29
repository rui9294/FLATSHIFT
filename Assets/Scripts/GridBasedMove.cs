using UnityEngine;

public class GridBasedMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gridSize = 1f;
    public LayerMask cellLayer; // ← 追加

    private bool isMoving = false;
    private Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        if (isMoving) return;

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        if (input.sqrMagnitude > 0.1f)
        {
            Vector3 dir = input.normalized;
            Vector3 destination = targetPos + dir * gridSize;

            if (IsCellPassable(destination, dir))
            {
                StartCoroutine(MoveTo(destination));
            }
            else
            {
                Debug.Log("❌ 通れない方向だよ");
            }
        }
    }

    System.Collections.IEnumerator MoveTo(Vector3 destination)
    {
        isMoving = true;
        while ((transform.position - destination).sqrMagnitude > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = destination;
        targetPos = destination;
        isMoving = false;
    }

    private bool IsCellPassable(Vector3 checkPos, Vector3 dir)
    {
        Collider[] hits = Physics.OverlapSphere(checkPos, 0.1f, cellLayer); // ← レイヤーで限定
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
