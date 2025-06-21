using UnityEngine;

public class TargetRevealOnMove : MonoBehaviour
{
    public Transform player;
    public GameObject targetCircle;
    public float revealTime = 10f;
    public float maxOffset = 0.45f;

    private Vector3 lastPosition;
    private float timer = 0f;
    private bool revealed = false;

    void Start()
    {
        lastPosition = player.position;
        targetCircle.SetActive(false);
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
                moveDir = Vector3.down;

            float zDist = Mathf.Abs(Camera.main.transform.position.z - player.position.z);
            float offsetX = Mathf.Clamp(0.5f + moveDir.x * maxOffset, 0.05f, 0.95f);
            float offsetY = Mathf.Clamp(0.5f + moveDir.y * maxOffset, 0.05f, 0.95f);

            Vector3 viewportSpawn = new Vector3(offsetX, offsetY, zDist);
            Vector3 spawnWorldPos = Camera.main.ViewportToWorldPoint(viewportSpawn);

            targetCircle.transform.position = spawnWorldPos;
            targetCircle.SetActive(true);

            // ここで演出を発動
            GrayCircleZoomFocus zoomFocus = targetCircle.GetComponent<GrayCircleZoomFocus>();
            if (zoomFocus != null)
            {
                zoomFocus.StartFocus();
            }

            Debug.Log("灰丸スポーン at " + spawnWorldPos);
        }
    }
}
