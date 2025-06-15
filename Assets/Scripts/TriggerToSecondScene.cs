using UnityEngine;
using UnityEngine.SceneManagement;

public class GrayCircleTriggerToSecondScene : MonoBehaviour
{
    public float delayBeforeSecondScene = 2f;  // 何秒待ってからシーンを切り替えるか
    public string nextSceneName = "SecondScene";  // 遷移先のシーン名

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            Debug.Log("プレイヤーが灰丸に接触！シーン遷移の準備中…");
            Invoke("LoadSecondScene", delayBeforeSecondScene);
        }
    }

    private void LoadSecondScene()
    {
        Debug.Log("次のシーンへ移動！");
        SceneManager.LoadScene("SecondScene");
    }
}
