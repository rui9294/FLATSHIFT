using UnityEngine;

public class PlayerDotCollision : MonoBehaviour
{
    [SerializeField] private AudioSource seSource;  // 効果音再生用 AudioSource
    [SerializeField] private AudioClip passSE;      // 白状態で通過したときのSE

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MelodyDot"))
        {
            MelodyDotState dotState = other.GetComponent<MelodyDotState>();
            if (dotState != null)
            {
                if (dotState.IsPassable())
                {
                    Debug.Log("白状態：通過OK");

                    // 効果音を鳴らす
                    if (seSource != null && passSE != null)
                    {
                        seSource.PlayOneShot(passSE);
                    }
                }
                else
                {
                    Debug.Log("黒状態：進行ブロック（ゲームオーバーではない）");
                    // 通れないだけなので、何もしなくてOK
                }
            }
        }
    }
}
