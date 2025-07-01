using UnityEngine;

public class ColorDotState : MonoBehaviour
{
    public enum DotType { Gray, Red, Blue }  // 必要に応じて追加
    public DotType dotType;

    public void DisappearIfMatch(DotType waveType)
    {
        if (dotType == waveType)
        {
            gameObject.SetActive(false); // 消す or アニメーション
        }
    }
}
