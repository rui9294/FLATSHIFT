using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameHandler : MonoBehaviour
{
    public string sceneName = "GameScene"; // �J�ڐ�̃V�[������������

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
