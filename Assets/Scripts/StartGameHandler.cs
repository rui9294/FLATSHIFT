using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameHandler : MonoBehaviour
{
    public string sceneName = "GameScene"; // ‘JˆÚæ‚ÌƒV[ƒ“–¼‚ğ‚±‚±‚É

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
