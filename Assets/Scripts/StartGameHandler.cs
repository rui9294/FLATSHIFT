using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameHandler : MonoBehaviour
{
    public string sceneName = "GameScene"; // 遷移先のシーン名をここに

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
