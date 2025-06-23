using UnityEngine;

public class MelodyDotSpawner : MonoBehaviour
{
    public GameObject melodyDotPrefab;
    public float spawnInterval = 1.5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnMelodyDot();
            timer = 0f;
        }
    }

    void SpawnMelodyDot()
    {
        // 画面外の上（中央）にスポーンさせる
        Camera cam = Camera.main;

        // Zはカメラからの距離なので、Z=0のオブジェクトを映すにはカメラのZも考慮
        float zDistance = Mathf.Abs(cam.transform.position.z);  // 例：10f

        // 画面上の少し外側（Y=1.1）にスポーン
        Vector3 viewportPos = new Vector3(0.5f, 1.1f, zDistance);
        Vector3 worldPos = cam.ViewportToWorldPoint(viewportPos);

        Instantiate(melodyDotPrefab, worldPos, Quaternion.identity);
    }
}
