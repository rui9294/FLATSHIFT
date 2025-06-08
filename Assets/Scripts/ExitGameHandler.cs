using UnityEngine;

public class ExitGameHandler : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタ停止用（デバッグ用）
#endif
    }
}
