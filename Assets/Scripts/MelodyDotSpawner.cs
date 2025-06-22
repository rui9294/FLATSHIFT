using UnityEngine;

public class MelodyDotSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dotPrefab;     // ��������Dot�̃v���n�u
    [SerializeField] private Transform player;         // �v���C���[�ւ̎Q��
    [SerializeField] private float spawnInterval = 2f; // �����Ԋu�i�b�j
    [SerializeField] private float spawnOffsetY = 10f; // �v���C���[����ɐ������鋗��

    private float timer = 0f;

    void Update()
    {
        if (player == null || dotPrefab == null)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnDot();
            timer = 0f;
        }
    }

    private void SpawnDot()
    {
        Vector3 spawnPos = new Vector3(player.position.x, player.position.y + spawnOffsetY, 0f);
        Instantiate(dotPrefab, spawnPos, Quaternion.identity);
    }
}
