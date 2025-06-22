using UnityEngine;

public class PlayerDotCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D: " + collision.collider.name);

        if (collision.collider.CompareTag("MelodyDot"))
        {
            Debug.Log("����ԂłԂ������I");
            // �����Ƀv���C���[���~�߂鏈���Ȃ�
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
                Debug.Log("����ԁF�ʉ�OK");
            }
            else
            {
                Debug.Log("������Ȃ����� Trigger �o�R�Œʉ߂����H");
            }
        }
    }
}
