using UnityEngine;

public class PlayerDotMove0D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    public bool canMove = true;  // © ’Ç‰ÁI

    void Update()
    {
        if (!canMove) return; // © ƒtƒ‰ƒO‚ª false ‚Ì‚Æ‚«‚ÍˆÚ“®‚µ‚È‚¢

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(moveX, moveZ, 0).normalized;

        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
