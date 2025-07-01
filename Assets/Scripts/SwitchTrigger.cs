using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public GameObject grayWaveObject;  // アクティブ化・発動する波紋オブジェクト
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // 波紋の位置をスイッチに合わせる
            grayWaveObject.transform.position = transform.position;

            // スケールを初期化
            grayWaveObject.transform.localScale = Vector3.one;

            // アクティブにしてから波紋を発動
            grayWaveObject.SetActive(true);
            grayWaveObject.GetComponent<ColorWaveEffect>().StartWave();
        }
    }
}
