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
            Debug.LogError("cellPrefab���ݒ肳��Ă��܂���I");
            return;
        }

        Vector3 origin = transform.position;

        // �c�����̃Z���iX = 0�j
        for (int y = 0; y < verticalCells; y++)
        {
            Vector3 pos = origin + new Vector3(0f, y * spacing, 0f);
            CreateCell(pos, PassableCell.Axis.Vertical);
        }

        // �������̃Z���iY = ���S�j
        float centerY = (verticalCells / 2) * spacing;
        for (int x = -horizontalCells / 2; x <= horizontalCells / 2; x++)
        {
            Vector3 pos = origin + new Vector3(x * spacing, centerY, 0f);

            if (x == 0)
            {
                // ���������_�͗������ɒʂ��
                CreateCell(pos, PassableCell.Axis.Both);
            }
            else if (Mathf.Abs(x) <= 1)
            {
                // �����_�̍��E1�}�X�����������ɒʂ��悤�ɂ���
                CreateCell(pos, PassableCell.Axis.Horizontal);
            }
            else
            {
                // �ʍs�s�Z���iOptional: �z�u���Ȃ��ł�OK�j
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
            Debug.LogWarning("PassableCell ���A�^�b�`����Ă��Ȃ��Z����������܂����I");
        }
    }
}
