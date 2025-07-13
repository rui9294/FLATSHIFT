using UnityEngine;
using System.Collections.Generic;

public class PlayerDotMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public LayerMask cellLayer;

    private Vector3 moveDir;
    private Vector3 targetPos;
    private bool isMoving = false;

    private HashSet<Vector2Int> blockedCells = new HashSet<Vector2Int>();

    private void Start()
    {
        // 初期位置グリッド吸着
        targetPos = SnapToGrid(transform.position);
        transform.position = targetPos;

        // 障害物スキャン
        ScanForObstacles();
    }

    private void Update()
    {
        // 強制グリッド吸着（ズレ防止）
        if (!isMoving && moveDir == Vector3.zero)
        {
            transform.position = SnapToGrid(transform.position);
        }

        if (!isMoving)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            moveDir = new Vector3(h, v, 0).normalized;

            if (moveDir != Vector3.zero)
            {
                Vector3 nextPos = SnapToGrid(transform.position + moveDir);
                Vector2Int nextGrid = Vector2Int.RoundToInt(nextPos);

                if (!blockedCells.Contains(nextGrid))
                {
                    targetPos = nextPos;
                    isMoving = true;
                }
                else
                {
                    Debug.Log("❌ そのマスは障害物だよ！");
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                transform.position = targetPos;
                transform.position = SnapToGrid(transform.position);
                isMoving = false;
            }
        }
    }

    private void ScanForObstacles()
    {
        blockedCells.Clear();

        ObstacleMarker[] obstacles = GameObject.FindObjectsOfType<ObstacleMarker>();
        foreach (var obstacle in obstacles)
        {
            Vector2Int gridPos = Vector2Int.RoundToInt(obstacle.transform.position);
            blockedCells.Add(gridPos);
            Debug.Log($"🚫 障害物登録: {gridPos}");
        }
    }

    private Vector3 SnapToGrid(Vector3 pos)
    {
        return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0f);
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(targetPos, Vector3.one * 0.9f);
    }
}
