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
            Debug.Log("StartFocus() called");
            StartCoroutine(FocusSequence());
        }
    }

    private IEnumerator FocusSequence()
    {
        hasFocused = true;

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, originalCamPos.z);
        Debug.Log("Going to gray circle at: " + targetPos + " over " + focusMoveDuration + "s");
        yield return MoveCamera(mainCamera.transform.position, targetPos, focusMoveDuration);

        Debug.Log("Waiting " + stayFocusedDuration + " seconds...");
        yield return new WaitForSeconds(stayFocusedDuration);
        Debug.Log("Waited done.");

        Vector3 returnPos = new Vector3(player.position.x, player.position.y + 0.01f, originalCamPos.z);
        Debug.Log("Returning to player at: " + returnPos + " over " + returnMoveDuration + "s");
        yield return MoveCamera(mainCamera.transform.position, returnPos, returnMoveDuration);

        if (playerMovementScript != null)
            playerMovementScript.enabled = true;

        Debug.Log("FocusSequence completed.");
    }


    private IEnumerator MoveCamera(Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            Vector3 newPos = Vector3.Lerp(from, to, t);
            mainCamera.transform.position = newPos;
            Debug.Log($"[MoveCamera] t={t:F2}, pos={newPos}");
            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = to;
        Debug.Log($"[MoveCamera] Final position reached: {to}");
    }
}
