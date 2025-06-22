using UnityEngine;

public class MelodyDotSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dotPrefab;     // 生成するDotのプレハブ
    [SerializeField] private Transform player;         // プレイヤーへの参照
    [SerializeField] private float spawnInterval = 2f; // 生成間隔（秒）
    [SerializeField] private float spawnOffsetY = 10f; // プレイヤーより上に生成する距離

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
