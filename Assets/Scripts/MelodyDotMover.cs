using UnityEngine;

public class MelodyDotMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (transform.position.y < -6f) // �J�����̌����Ȃ����̕�
        {
            Destroy(gameObject);
            Debug.Log("MelodyDot destroyed");
        }
    }
}
