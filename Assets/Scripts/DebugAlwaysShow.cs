using UnityEngine;

public class DebugAlwaysShow : MonoBehaviour
{
    void Start()
    {
        var sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        sr.sortingOrder = 100;
        Debug.Log("GrayCircle �����\���e�X�g�FSpriteRenderer Active");
    }
}
