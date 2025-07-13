using UnityEngine;
using System.Collections.Generic;

public class PlayerDotMove : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Vector3 moveDir;
    private Vector3 targetPos;
    private bool isMoving = false;

    private HashSet<Vector2Int> blockedCells = new HashSet<Vector2Int>();
    private HashSet<Vector2Int> pathCells = new HashSet<Vector2Int>();

    private void Start()
    {
        targetPos = SnapToGrid(transform.position);
        transform.position = targetPos;

        ScanForObstacles();
        ScanForPathLines();
    }

    private void Update()
    {
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
                Vector2Int nextGrid = Vector2Int.RoundToInt(SnapToGrid(transform.position + moveDir));

                if (IsCellPassable(nextGrid))
                {
                    targetPos = new Vector3(nextGrid.x, nextGrid.y, 0f);
                    isMoving = true;
                }
                else
                {
                    Debug.Log("❌ 通れないマス");
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

    private bool IsCellPassable(Vector2Int grid)
    {
        if (!pathCells.Contains(grid))
        {
            Debug.Log("🛣 PathLineがない！");
            return false;
        }

        if (blockedCells.Contains(grid))
        {
            Debug.Log("🚫 障害物がある！");
            return false;
        }

        return true;
    }

    private void ScanForObstacles()
    {
        blockedCells.Clear();

        ObstacleState[] obstacles = GameObject.FindObjectsByType<ObstacleState>(FindObjectsSortMode.None);
        foreach (var obs in obstacles)
        {
            if (!obs.IsPassable())
            {
                Vector2Int grid = Vector2Int.RoundToInt(obs.transform.position);
                blockedCells.Add(grid);
            }
        }
    }

    private void ScanForPathLines()
    {
        pathCells.Clear();

        PathLineMarker[] paths = GameObject.FindObjectsByType<PathLineMarker>(FindObjectsSortMode.None);
        foreach (var path in paths)
        {
            Vector2Int start = path.startGrid;
            Vector2Int end = path.endGrid;

            if (start.x == end.x)
            {
                for (int y = Mathf.Min(start.y, end.y); y <= Mathf.Max(start.y, end.y); y++)
                {
                    pathCells.Add(new Vector2Int(start.x, y));
                }
            }
            else if (start.y == end.y)
            {
                for (int x = Mathf.Min(start.x, end.x); x <= Mathf.Max(start.x, end.x); x++)
                {
                    pathCells.Add(new Vector2Int(x, start.y));
                }
            }
            else
            {
                Debug.LogWarning($"PathLineMarker {path.name} は縦または横の直線である必要があります！");
            }
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
