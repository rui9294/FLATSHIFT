using UnityEngine;

public class PassableGridBuilder : MonoBehaviour
{
    public GameObject cellPrefab;
    public int verticalCells = 10;
    public int horizontalCells = 10;
    public float spacing = 1f;

    void Start()
    {
        BuildGrid();
    }

    void BuildGrid()
    {
        if (cellPrefab == null)
        {
            Debug.LogError("cellPrefabが設定されていません！");
            return;
        }

        Vector3 origin = transform.position;

        // 縦方向のセル（X = 0）
        for (int y = 0; y < verticalCells; y++)
        {
            Vector3 pos = origin + new Vector3(0f, y * spacing, 0f);
            CreateCell(pos, PassableCell.Axis.Vertical);
        }

        // 横方向のセル（Y = 中心）
        float centerY = (verticalCells / 2) * spacing;
        for (int x = -horizontalCells / 2; x <= horizontalCells / 2; x++)
        {
            Vector3 pos = origin + new Vector3(x * spacing, centerY, 0f);

            if (x == 0)
            {
                // 中央交差点は両方向に通れる
                CreateCell(pos, PassableCell.Axis.Both);
            }
            else if (Mathf.Abs(x) <= 1)
            {
                // 交差点の左右1マスだけ横方向に通れるようにする
                CreateCell(pos, PassableCell.Axis.Horizontal);
            }
            else
            {
                // 通行不可セル（Optional: 配置しないでもOK）
                CreateCell(pos, PassableCell.Axis.None);
            }
        }
    }

    void CreateCell(Vector3 position, PassableCell.Axis axis)
    {
        GameObject cell = Instantiate(cellPrefab, position, Quaternion.identity, transform);
        PassableCell pc = cell.GetComponent<PassableCell>();
        if (pc != null)
        {
            pc.allowedAxis = axis;
        }
        else
        {
            Debug.LogWarning("PassableCell がアタッチされていないセルが見つかりました！");
        }
    }
}
