using UnityEngine;
using System.Collections;

public class GrayCircleZoomFocus : MonoBehaviour
{
    public Transform player;
    public PlayerDotMove0D playerMovementScript; // 修正：DotMove0Dに対応

    [SerializeField] private float focusMoveDuration = 2f;      // 灰丸へ移動時間
    [SerializeField] private float stayFocusedDuration = 2f;    // 灰丸で止まる時間
    [SerializeField] private float returnMoveDuration = 1.5f;   // 黒丸へ戻る時間

    private Camera mainCamera;
    private Vector3 originalCamPos;
    private bool hasFocused = false;
    private CameraFollow cameraFollowScript;

    void Awake()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found! Make sure your camera has the 'MainCamera' tag.");
        }

        cameraFollowScript = mainCamera.GetComponent<CameraFollow>();
        if (cameraFollowScript == null)
        {
            Debug.LogWarning("CameraFollow script not found on Main Camera.");
        }

        originalCamPos = mainCamera.transform.position;
    }

    public void StartFocus()
    {
        if (!hasFocused)
        {
            StartCoroutine(FocusSequence());
        }
    }

    private IEnumerator FocusSequence()
    {
        hasFocused = true;

        // 入力を止める
        if (playerMovementScript != null)
            playerMovementScript.canMove = false;

        // カメラの追従を止める
        if (cameraFollowScript != null)
            cameraFollowScript.isFrozen = true;

        // カメラを灰丸に移動
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, originalCamPos.z);
        yield return MoveCamera(mainCamera.transform.position, targetPos, focusMoveDuration);

        // 灰丸で止まる時間
        yield return new WaitForSeconds(stayFocusedDuration);

        // カメラをプレイヤーの元位置へ戻す
        Vector3 returnPos = new Vector3(player.position.x, player.position.y, originalCamPos.z);
        yield return MoveCamera(mainCamera.transform.position, returnPos, returnMoveDuration);

        // カメラ追従とプレイヤー移動を再開
        if (cameraFollowScript != null)
            cameraFollowScript.isFrozen = false;

        if (playerMovementScript != null)
            playerMovementScript.canMove = true;
    }

    private IEnumerator MoveCamera(Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            Vector3 newPos = Vector3.Lerp(from, to, t);
            mainCamera.transform.position = newPos;
            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = to;
    }
}
