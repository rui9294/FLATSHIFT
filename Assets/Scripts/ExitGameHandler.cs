using UnityEngine;

public class ExitGameHandler : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^��~�p�i�f�o�b�O�p�j
#endif
    }
}
