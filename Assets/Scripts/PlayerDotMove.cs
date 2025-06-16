using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDotMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool verticalOnly = false;

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "SecondScene")
        {
            verticalOnly = true;
        }
    }

    void Update()
    {
        float horizontal = verticalOnly ? 0f : Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;
        transform.position += move;
    }
}
