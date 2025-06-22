using UnityEngine;

public class PlayerDotCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D: " + collision.collider.name);

        if (collision.collider.CompareTag("MelodyDot"))
        {
            Debug.Log("黒状態でぶつかった！");
            // ここにプレイヤーを止める処理など
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D: " + other.name);

        if (other.CompareTag("MelodyDot"))
        {
            MelodyDotState state = other.GetComponent<MelodyDotState>();
            if (state != null && state.IsPassable())
            {
                Debug.Log("白状態：通過OK");
            }
            else
            {
                Debug.Log("白じゃないけど Trigger 経由で通過した？");
            }
        }
    }
}
