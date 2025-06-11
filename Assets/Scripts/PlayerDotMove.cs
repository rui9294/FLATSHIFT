using UnityEngine;

public class PlayerDotMove : MonoBehaviour
{
    public float speed = 300f; // “®‚­‘¬‚³
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        rectTransform.anchoredPosition += new Vector2(move.x, move.y) * speed * Time.deltaTime;
    }
}
