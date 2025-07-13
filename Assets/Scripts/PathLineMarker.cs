using UnityEngine;

public class PathLineMarker : MonoBehaviour
{
    public Vector2Int startGrid = new Vector2Int(0, 0);
    public Vector2Int endGrid = new Vector2Int(0, 0);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector3 start = new Vector3(startGrid.x, startGrid.y, 0f);
        Vector3 end = new Vector3(endGrid.x, endGrid.y, 0f);
        Gizmos.DrawLine(start, end);
    }
}
