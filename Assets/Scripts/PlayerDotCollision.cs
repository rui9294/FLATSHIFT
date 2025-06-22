using UnityEngine;

public class PlayerDotCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger hit: " + other.name); // �ǉ��I

        if (other.CompareTag("MelodyDot"))
        {
            MelodyDotState dotState = other.GetComponent<MelodyDotState>();
            if (dotState != null)
            {
                if (dotState.IsPassable())
                {
                    Debug.Log("����ԁF�ʉ�OK");
                }
                else
                {
                    Debug.Log("����ԁF�Q�[���I�[�o�[�I");
                }
            }
        }
    }
}
