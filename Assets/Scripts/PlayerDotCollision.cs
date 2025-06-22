using UnityEngine;

public class PlayerDotCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger hit: " + other.name); // 追加！

        if (other.CompareTag("MelodyDot"))
        {
            MelodyDotState dotState = other.GetComponent<MelodyDotState>();
            if (dotState != null)
            {
                if (dotState.IsPassable())
                {
                    Debug.Log("白状態：通過OK");
                }
                else
                {
                    Debug.Log("黒状態：ゲームオーバー！");
                }
            }
        }
    }
}
