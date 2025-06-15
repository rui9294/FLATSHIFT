using UnityEngine;

public class TargetRevealOnMove : MonoBehaviour
{
    public Transform player;
    public GameObject targetCircle;
    public float revealTime = 10f;
    public float maxOffset = 0.45f; // 画面中心からどれくらいずらすか（1以上にしない）

    private Vector3 lastPosition;
    private float timer = 0f;
    private bool revealed = false;

    void Start()
    {
        lastPosition = player.position;
        targetCircle.SetActive(false); // 最初は非表示
    }

    void Update()
    {
        Vector3 moveDir = (player.position - lastPosition).normalized;

        if (Vector3.Distance(player.position, lastPosition) > 0.01f)
        {
            timer += Time.deltaTime;
            lastPosition = player.position;
        }

        if (timer >= revealTime && !revealed)
        {
            revealed = true;

            if (moveDir == Vector3.zero)
                moveDir = Vector3.down; // 仮の方向（動いてない場合）

            // カメラからプレイヤーまでの距離
            float zDist = Mathf.Abs(Camera.main.transform.position.z - player.position.z);

            // Viewport の中心を基準に、方向ベクトルでずらす（最大でも0.05〜0.95の範囲）
            float offsetX = Mathf.Clamp(0.5f + moveDir.x * maxOffset, 0.05f, 0.95f);
            float offsetY = Mathf.Clamp(0.5f + moveDir.y * maxOffset, 0.05f, 0.95f);

            Vector3 viewportSpawn = new Vector3(offsetX, offsetY, zDist);
            Vector3 spawnWorldPos = Camera.main.ViewportToWorldPoint(viewportSpawn);

            targetCircle.transform.position = spawnWorldPos;
            targetCircle.SetActive(true);

            Debug.Log("灰丸スポーン at " + spawnWorldPos);
        }
    }
}
