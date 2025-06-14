using UnityEngine;

public class PlayerDotMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;
        transform.position += move;
    }
}
