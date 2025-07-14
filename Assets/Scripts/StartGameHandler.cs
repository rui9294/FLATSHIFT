using UnityEngine;

public class StartGameHandler : MonoBehaviour
{
    [SerializeField] private string sceneName = "GameScene";

    public void StartGame()
    {
        SceneFader.Instance.FadeToScene(sceneName);
    }
}
