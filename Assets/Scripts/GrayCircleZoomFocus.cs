using UnityEngine;
using System.Collections;

public class GrayCircleZoomFocus : MonoBehaviour
{
    public Transform player;
    public PlayerDotMove playerMovementScript;

    [SerializeField] private float focusMoveDuration = 2f;      // 灰丸へ移動時間
    [SerializeField] private float stayFocusedDuration = 2f;    // 灰丸で止まる時間
    [SerializeField] private float returnMoveDuration = 1.5f;   // 黒丸へ戻る時間

    private Camera mainCamera;
    private Vector3 originalCamPos;
    private bool hasFocused = false;

    void Awake()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found! Make sure your camera has the 'MainCamera' tag.");
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

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        // 灰丸（このオブジェクト）へのカメラ移動
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, originalCamPos.z);
        yield return MoveCamera(mainCamera.transform.position, targetPos, focusMoveDuration);

        // 灰丸でしばらく停止
        yield return new WaitForSeconds(stayFocusedDuration);

        // 🔧プレイヤーの現在位置をこのタイミングで再取得
        Vector3 returnPos = new Vector3(player.position.x, player.position.y, originalCamPos.z);

        // プレイヤーへカメラを戻す
        yield return MoveCamera(mainCamera.transform.position, returnPos, returnMoveDuration);

        if (playerMovementScript != null)
            playerMovementScript.enabled = true;
    }

    private IEnumerator MoveCamera(Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            mainCamera.transform.position = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = to;
    }
}
